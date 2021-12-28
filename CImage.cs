using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace BatchImageConverter
{
    /// <summary>
    /// Provides to some image processing works
    /// </summary>
    public class CImage
    {
        /// <summary>
        /// Struct for overlay on image for text
        /// </summary>
        [Serializable]
        public class TextOverlay
        {
            public XPosition xpos = XPosition.Right;
            public YPosition ypos = YPosition.Up; 
            public int dim = 1;
            public string Text = "default text";
            public Font font = new Font("arial",12);
            public short trasp = 150;
            public short traspshadow = 120;
            public short transparencyshape = 100;
            public Color frontcolor = Color.Red;
            public Color shapecolor = Color.Gray;
            public bool Shape = false;
            public bool ShapeRectangle = true;
            public bool ShapeEllipse = false;
            public bool D3effetc = false;
        }

        /// <summary>
        /// Struct for overlay on image for image
        /// </summary>
        [Serializable]
        public class ImageOverlay
        {
            public string path = "Error";
            public XPosition xpos = XPosition.Left;
            public YPosition ypos = YPosition.Bottom;
            public short trasp = 150;
            public int percdim = 15;
            public Color traspkey = Color.Transparent;
        }

        /// <summary>
        /// Position X
        /// </summary>
        [Serializable]
        public enum XPosition
        {
            Center = 0,
            Left = 1,
            Right = 2
        }

        /// <summary>
        /// Position Y
        /// </summary>
        [Serializable]
        public enum YPosition
        {
            Center = 0,
            Up = 1,
            Bottom = 2
        }   
        private InterpolationMode intmode = InterpolationMode.HighQualityBicubic;

        /// <summary>
        /// Constructor
        /// </summary>
        public CImage()
        {
            
        }

        /// <summary>
        /// Resize the image fast but with low quality
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <param name="destWidth"></param>
        /// <param name="destHeight"></param>
        public void Resizefast(ref Image imgPhoto, int destWidth, int destHeight)
        {
            imgPhoto = imgPhoto.GetThumbnailImage(destWidth, destHeight, null, System.IntPtr.Zero);
        }

        /// <summary>
        ///  Resize the image with high quality
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <param name="destWidth"></param>
        /// <param name="destHeight"></param>
        public void Resize(ref Bitmap imgPhoto, int destWidth, int destHeight, int quality)
        {
            resizemode(quality);
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            if (sourceWidth == destWidth && sourceHeight == destHeight) return; //quit if the resize is not required
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;
            // Creates a new bitmap with the same propertyes of the original one
            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,PixelFormat.Format24bppRgb);
            // Set the resolution that are equal to the original image
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,imgPhoto.VerticalResolution);
            // Creates a new graphic object from the new bitmap (that is actually "blank")
            Graphics imgGraphic = Graphics.FromImage(bmPhoto);
            // Set the interpolation mode (es Hight quality bicubic)
            imgGraphic.InterpolationMode = intmode;
            // Draws the original image into the new "blank" image but with the target size and without cropping
            imgGraphic.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);
            // Dispose the graphic object
            imgGraphic.Dispose();        
            // Assign the new bitmap on the old one
            imgPhoto.Dispose();
            imgPhoto = bmPhoto;
        }

        /// <summary>
        /// Put overlaytext on image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="text"></param>
        /// <param name="txtoverlay"></param>
        public void overlaytext(ref Bitmap img, TextOverlay txtoverlay)
        {
            string text = txtoverlay.Text;          // The text contining the overlay message
            if (text.Length < 1) text = "no text";
            // "dim" is used to shrink the text (the size is dynamic)
            if (txtoverlay.dim == 0) txtoverlay.dim = 1;
            if (txtoverlay.dim > 8) txtoverlay.dim = 8;
            int imgWidth = img.Width;
            int imgHeight = img.Height;
            // Creates a new bitmap with the same propertyes of the original one
            Bitmap workingimg = new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb);
            workingimg.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            // Creates a graphic object from the new image
            Graphics imgGraphic = Graphics.FromImage(workingimg);
            // Set the smoothing mode
            imgGraphic.SmoothingMode = SmoothingMode.AntiAlias;
            // Set the text rendering
            imgGraphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // draw the original image on the new one, no crop or resize, the size is exactly the same
            imgGraphic.DrawImage(img, new Rectangle(0, 0, imgWidth, imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);

            Font TextFont = null;
            SizeF TextSize = new SizeF();
            PointF TextLocation = new PointF();     // the point that will contains the text location over the image
            float posx = 0f;
            float posy = 0f;
            int di = 12;
            // Set the style of the font
            FontStyle style = FontStyle.Regular;
            if (txtoverlay.font.Bold == true && txtoverlay.font.Italic == false) style = FontStyle.Bold;
            if (txtoverlay.font.Bold == true && txtoverlay.font.Italic == true) style = FontStyle.Bold | FontStyle.Italic;
            if (txtoverlay.font.Bold == false && txtoverlay.font.Italic == true) style = FontStyle.Italic;
            //if (txtoverlay.font.Strikeout == true) style = FontStyle.Strikeout;
            //if (txtoverlay.font.Underline == true) style = FontStyle.Underline;

            // Now we calculate the location of the text over image

            // X Position case
            switch (txtoverlay.xpos)
            {
                case XPosition.Center:
                    // Try to use a font with a dimension from bigger to lower and evalutate if the measure of the text can be contained
                    // into a region of the image
                    for (di = 80; di >= 2; di -= 2)
                    { 
                        TextFont = new Font(txtoverlay.font.FontFamily, di, style);
                        TextSize = imgGraphic.MeasureString(text, TextFont);
                        TextFont.Dispose();
                        if ((ushort)TextSize.Width < (ushort)imgWidth/txtoverlay.dim)   // Break if the text is just contained into
                            break;                                                      // Note that the "txtoverlay.dim" simulate a smaller image                                                                    
                    }                                                                   // so the text will be smaller
                    posx = (float)imgWidth / 2;
                    break;
                case XPosition.Left:
                    for (di = 80; di >= 2; di -= 2)
                    {
                        TextFont = new Font(txtoverlay.font.FontFamily, di, style);
                        TextSize = imgGraphic.MeasureString(text, TextFont);
                        TextFont.Dispose();
                        if ((ushort)TextSize.Width < (ushort)imgWidth /2/txtoverlay.dim)
                            break;
                    }
                    posx = (float)imgWidth * (1 + (float)txtoverlay.dim - 1) / (4 + (float)txtoverlay.dim - 1);
                    break;
                case XPosition.Right:
                    for (di = 80; di >= 2; di -= 2)
                    {
                        TextFont = new Font(txtoverlay.font.FontFamily, di, style);
                        TextSize = imgGraphic.MeasureString(text, TextFont);
                        TextFont.Dispose();
                        if ((ushort)TextSize.Width < (ushort)imgWidth /2/txtoverlay.dim)
                            break;
                    }
                    posx = (float)imgWidth * (3 + (float)txtoverlay.dim-1)/ (4+(float)txtoverlay.dim-1) ;
                    break;
            }

            // Y Position case
            switch (txtoverlay.ypos)
            {
                case YPosition.Bottom:
                    // Set the y position based on the percent of container image
                    posy = (float)imgHeight - ((float)imgHeight * 5 / 100) - TextSize.Height / 2;
                    break;
                case YPosition.Center:
                    posy = (float)imgHeight - ((float)imgHeight * 50 / 100) - TextSize.Height / 2;
                    break;
                case YPosition.Up:
                    posy = (float)imgHeight - ((float)imgHeight * 93 / 100) - TextSize.Height / 2;
                    break;
            }

            // if the text size is smaller than 2 we can't make overlay because
            if (di < 2) return;

            // Creates a new font basaed on the user chooses and the size just calculated
            TextFont = new Font(txtoverlay.font.FontFamily, di, style);

            TextLocation = new PointF(posx,posy);
            
            // Align the text in the middle (center) of the image
            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;
 
            // Create a new brush
            SolidBrush BrushShadow = new SolidBrush(Color.FromArgb(txtoverlay.traspshadow, 0, 0, 0)); // Alpha, Red, Green, Blue
            
            // Draw the text over the image with black color. This is the shadow of the text over the image
            imgGraphic.DrawString(text, TextFont, BrushShadow, TextLocation + new SizeF((float)TextSize.Height*0.04f,(float)TextSize.Height*0.04f), StrFormat);
            
            // Dispose the brush
            BrushShadow.Dispose();

            // Draw the shape (rectangle or ellipse) too
            if (txtoverlay.Shape)
            {
                SolidBrush BrushShape = new SolidBrush(Color.FromArgb(txtoverlay.transparencyshape, txtoverlay.shapecolor.R, txtoverlay.shapecolor.G, txtoverlay.shapecolor.B));

                if (txtoverlay.ShapeEllipse) imgGraphic.FillEllipse(BrushShape, TextLocation.X - TextSize.Width / 2, TextLocation.Y, TextSize.Width, TextSize.Height);
                if (txtoverlay.ShapeRectangle) imgGraphic.FillRectangle(BrushShape, TextLocation.X - TextSize.Width / 2, TextLocation.Y, TextSize.Width, TextSize.Height);

                BrushShape.Dispose();
            }

            // Create a 3D effect redrawing the text 
            SolidBrush BrushFront;
            if (txtoverlay.D3effetc)
            {
                // 3D
                int ti = (int)((float)TextSize.Height * 0.1);
                if (ti == 0) ti = 1;
                BrushFront = new SolidBrush(Color.FromArgb((int)((float)txtoverlay.trasp), txtoverlay.frontcolor.R, txtoverlay.frontcolor.G, txtoverlay.frontcolor.B));
                for (float i = 0; i < (float)ti; i+=0.3f)
                {
                    if (BrushFront != null) BrushFront.Dispose();
                    // Draw a text with progressive increasing transparence with shifted position 
                    BrushFront = new SolidBrush(Color.FromArgb((int) ((float)txtoverlay.trasp / (i+1)), txtoverlay.frontcolor.R, txtoverlay.frontcolor.G, txtoverlay.frontcolor.B));
                    imgGraphic.DrawString(text, TextFont, BrushFront, TextLocation+new SizeF(i-ti,i-ti), StrFormat);
                }
            }
            else
            {
                // Simple
                BrushFront = new SolidBrush(Color.FromArgb(txtoverlay.trasp, txtoverlay.frontcolor.R, txtoverlay.frontcolor.G, txtoverlay.frontcolor.B));
                imgGraphic.DrawString(text, TextFont, BrushFront, TextLocation, StrFormat);
            }

            BrushFront.Dispose();

            img.Dispose();
            img = workingimg;
        }

        /// <summary>
        /// Make a shadow effect on image
        /// </summary>
        /// <param name="img"></param>
        public void makeshadow(ref Bitmap img, Color backcolor)
        {
            int imgWidth = img.Width;
            int imgHeight = img.Height;
            // Create a new bitmap with the same size of the original image
            Bitmap workingimg = new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb);
            workingimg.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            // Create a new graphic object from the new bitmap
            Graphics imgGraphic = Graphics.FromImage(workingimg);
            imgGraphic.SmoothingMode = SmoothingMode.HighQuality;
            // not used
            imgGraphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // Set the interpolation mode
            imgGraphic.InterpolationMode = intmode;

            // Calculate the new size for drawing the originalimage that is reduced to mantein the total target image size
            int width = (int)((float)img.Width * 94 / 100);
            int height = (int)((float)img.Height * 94 / 100);

            // Create a new brush semitransparent
            SolidBrush BrushShadow = new SolidBrush(Color.FromArgb(10, 0, 0, 0));
            
            // Set the background color based on the user preference
            imgGraphic.Clear(backcolor);

            // Create the shadow shifting semi-transparent rectangle over the empty bitmap 
            float steps = ((float)imgWidth - width) / 20;
            float sottr = 0f;
            for (float i = 0; i < 10; i++)
            {
                imgGraphic.FillRectangle(BrushShadow, new Rectangle((int)(sottr), (int)sottr, (int)((float)width+sottr), (int)((float)height+sottr)));
                sottr += steps;
            }
            // Finally draw the original image but shrinked
            imgGraphic.DrawImage(img, new Rectangle(0, 0, width, height), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);

            BrushShadow.Dispose();

            img.Dispose();
            img = workingimg;
        }

        /// <summary>
        /// Put the overlayimage on the image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="imgoverlay"></param>
        public void overlayimage(ref Bitmap img, ref Bitmap waterimg, ImageOverlay imgoverlay)
        {
            int imgWidth = img.Width;
            int imgHeight = img.Height;
            // Create a new Bitmap based on the size of the original one
            Bitmap nuova = new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb);
            nuova.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            int wtWidth = waterimg.Width;
            int wtHeight = waterimg.Height;

            // create a graphic from image
            Graphics grGraphic = Graphics.FromImage(nuova);
            grGraphic.SmoothingMode = SmoothingMode.HighQuality;
            // draw the origina image
            grGraphic.DrawImage(img, new Rectangle(0, 0, imgWidth, imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);
            // Set the interpolation mode
            grGraphic.InterpolationMode = intmode;
            
            // Finally put the watermark image

            ImageAttributes imageAttributes = new ImageAttributes();
            float trasp = (float)imgoverlay.trasp / 255;
            if (trasp > 1) trasp = 1;
            if (trasp < 0) trasp = 0;
            // Create a new colormatrix that is a 5 x 5 matrix with columns / rows that rapresent: Red, Green, Blue and Alpha (transparence). The "1" means inalterate (x * 1 = x) 
            float[][] Elements = { 
												new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},       
												new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},        
												new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},        
												new float[] {0.0f,  0.0f,  0.0f,  trasp, 0.0f},        
												new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}};
            ColorMatrix colormatrix = new ColorMatrix(Elements);
            // Set the image attributes with our color matrix
            imageAttributes.SetColorMatrix(colormatrix, ColorMatrixFlag.Default,ColorAdjustType.Bitmap);

            // Remap the color of the image to substitute a color with another
            ColorMap colormap = new ColorMap();
            colormap.OldColor = imgoverlay.traspkey;        // old color (user defined)
            colormap.NewColor = Color.FromArgb(0, 0, 0, 0); // new color (new fully transparent color)
            // This operation permits to set the transparency key: substitute a color with a transparent one

            ColorMap[] remaptable = { colormap };
            // Set the image attributes
            imageAttributes.SetRemapTable(remaptable, ColorAdjustType.Bitmap);

            // Calculate the size of the watermark image
            float percrap = ((float)(imgWidth)) * (float)imgoverlay.percdim / 100;
            int dimx = (int)((float)percrap);
            int dimy = (int)(((float)dimx/(float)wtWidth*(float)wtHeight));

            // Calculate the location for the watermark image over the original one (graphic object)
            float posx = 0f;
            float posy = 0f;
            // X Position case
            switch (imgoverlay.xpos)
            {
                case XPosition.Center:
                    posx = (float)imgWidth / 2-(float) dimx/2;
                    break;
                case XPosition.Left:
                    posx = (float)imgWidth * 2/ 100;
                    break;
                case XPosition.Right:
                    posx = (float)imgWidth * 98 / 100- (float)dimx;
                    break;
            }

            // Y Position case
            switch (imgoverlay.ypos)
            {
                case YPosition.Bottom:
                    posy = (float)imgHeight - ((float)imgHeight * 2 / 100) - (float)dimy;
                    break;
                case YPosition.Center:
                    posy = ((float)imgHeight * 50 / 100) - (float)dimy / 2;
                    break;
                case YPosition.Up:
                    posy = ((float)imgHeight * 2 / 100);
                    break;
            }
            
            // Finally draw the watermark image
            grGraphic.DrawImage(waterimg, new Rectangle((int)posx, (int)posy,dimx ,dimy ), 0, 0, wtWidth, wtHeight, GraphicsUnit.Pixel, imageAttributes);

            //PropertyItem pitem = null;
            //byte[] metaComment = { (byte)'S', (byte)'o', (byte)'l', (byte)'c', (byte)'h', (byte)'i', (byte)'e', (byte)'r', (byte)'e', (byte)'A', (byte)'i', (byte)'t' };
            //pitem.Value = metaComment;
            //pitem.Len = metaComment.Length;
            //pitem.Id = 0x0131;
            //nuova.SetPropertyItem(pitem);
            
            img.Dispose();
            img = nuova;
        }
        /// <summary>
        /// Set the quality for the resize
        /// </summary>
        /// <param name="indice"></param>
        public void resizemode(int indice)
        {
            switch (indice)
            {
                case 0:
                    intmode = InterpolationMode.HighQualityBicubic;
                    break;
                case 1:
                    intmode = InterpolationMode.Bicubic;
                    break;
                case 2:
                    intmode = InterpolationMode.High;
                    break;
                case 3:
                    intmode = InterpolationMode.HighQualityBilinear;
                    break;
                case 4:
                    intmode = InterpolationMode.Bilinear;
                    break;
                case 5:
                    intmode = InterpolationMode.Low;
                    break;
                case 6:
                    intmode = InterpolationMode.NearestNeighbor;
                    break;
                default:
                    intmode = InterpolationMode.HighQualityBicubic;
                    break;

            }
        }

        /// <summary>
        /// Obtain encoders information (used for jpeg quality definition)
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        /// <summary>
        /// Save image to file using JPEG encoder having the quality passed
        /// </summary>
        /// <param name="imgr"></param>
        /// <param name="filen"></param>
        /// <param name="qual"></param>
        public void save(ref Bitmap imgr, string filen, int qual)
        {
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, (long)qual);
            myEncoderParameters.Param[0] = myEncoderParameter;
            imgr.Save(filen, myImageCodecInfo, myEncoderParameters);
            myEncoderParameters.Dispose();
            myEncoderParameter.Dispose();
        }

    }

}
