using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteBlender
{
    public class MaskedSprite
    {
        private Bitmap originalImage;
        private Bitmap originalImage_mask;
        private Bitmap maskedImage;
        private Bitmap bmp;
        
        /// <summary>
        /// The entry point in which the masked image is drawn together and returned in the "GetMaskedImage" void
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="mask">The image's mask</param>
        public MaskedSprite(Image image, Image mask)
        {
            originalImage = Create32bppImageAndClearAlpha((Bitmap)image);
            originalImage_mask = Create32bppImageAndClearAlpha((Bitmap)mask);
            PrepareMaskImage();
        }
        public MaskedSprite(Bitmap image, Bitmap mask)
        {
            originalImage = Create32bppImageAndClearAlpha(image);
            originalImage_mask = Create32bppImageAndClearAlpha(mask);
            PrepareMaskImage();
        }

        public Bitmap GetMaskedImage
        {
            get
            {
                return maskedImage;
            }
        }

        #region This is ugly stuff
        private void PrepareMaskedImage()
        {
            if (this.originalImage != null && this.originalImage_mask != null)
            {
                if (this.originalImage.Width != this.originalImage_mask.Width || this.originalImage.Height != originalImage_mask.Height)
                {
                    MessageBox.Show("Error: mask and image must have the same size", "Error Creating Mask", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    //allocate the Masked image in ARGB format
                    this.maskedImage = Create32bppImageAndClearAlpha(this.originalImage);

                    BitmapData bmpData1 = maskedImage.LockBits(new Rectangle(0, 0, maskedImage.Width, maskedImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, maskedImage.PixelFormat);
                    byte[] maskedImageRGBAData = new byte[bmpData1.Stride * bmpData1.Height];
                    System.Runtime.InteropServices.Marshal.Copy(bmpData1.Scan0, maskedImageRGBAData, 0, maskedImageRGBAData.Length);

                    BitmapData bmpData2 = originalImage_mask.LockBits(new Rectangle(0, 0, originalImage_mask.Width, originalImage_mask.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, originalImage_mask.PixelFormat);
                    byte[] maskImageRGBAData = new byte[bmpData2.Stride * bmpData2.Height];
                    System.Runtime.InteropServices.Marshal.Copy(bmpData2.Scan0, maskImageRGBAData, 0, maskImageRGBAData.Length);

                    //copy the mask to the Alpha layer
                    for (int i = 0; i + 2 < maskedImageRGBAData.Length; i += 4)
                    {
                        maskedImageRGBAData[i + 3] = maskImageRGBAData[i];

                    }
                    System.Runtime.InteropServices.Marshal.Copy(maskedImageRGBAData, 0, bmpData1.Scan0, maskedImageRGBAData.Length);
                    bmp = maskedImage;
                    this.maskedImage.UnlockBits(bmpData1);
                    this.originalImage_mask.UnlockBits(bmpData2);
                    //bmp = maskedImage;
                    //this.previewBox.Image = maskedImage;

                }
            }
        }

        private void PrepareMaskImage()
        {
            if (originalImage_mask != null)
            {
                originalImage_mask = Create32bppImageAndClearAlpha(originalImage_mask);

                BitmapData bmpData = originalImage_mask.LockBits(new Rectangle(0, 0, originalImage_mask.Width, originalImage_mask.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, originalImage_mask.PixelFormat);

                byte[] maskImageRGBData = new byte[bmpData.Stride * bmpData.Height];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, maskImageRGBData, 0, maskImageRGBData.Length);


                byte greyLevel;
                bool opaque = false;
                //int OpacityThreshold = this.trackBar1.Value;
                bool invertedMask = true;//this.checkBoxInvertMask.Checked;
                for (int i = 0; i + 2 < maskImageRGBData.Length; i += 4)
                {
                    //convert to gray scale R:0.30 G=0.59 B 0.11
                    greyLevel = (byte)(0.3 * maskImageRGBData[i + 2] + 0.59 * maskImageRGBData[i + 1] + 0.11 * maskImageRGBData[i]);

                    if (opaque)
                    {
                        greyLevel = (greyLevel < 420/*OpacityThreshold*/) ? byte.MinValue : byte.MaxValue;
                    }
                    if (invertedMask)
                    {
                        greyLevel = (byte)(255 - (int)greyLevel);
                    }

                    maskImageRGBData[i] = greyLevel;
                    maskImageRGBData[i + 1] = greyLevel;
                    maskImageRGBData[i + 2] = greyLevel;

                }
                System.Runtime.InteropServices.Marshal.Copy(maskImageRGBData, 0, bmpData.Scan0, maskImageRGBData.Length);
                this.originalImage_mask.UnlockBits(bmpData);
                //this.spriteMask.Image = maskImage;
                // if the loaded image is available, we have everything to compute the masked image
                if (this.originalImage != null)
                {
                    PrepareMaskedImage();
                }
            }
        }

        private Bitmap Create32bppImageAndClearAlpha(Bitmap tmpImage)
        {
            // declare the new image that will be returned by the function
            Bitmap returnedImage = new Bitmap(tmpImage.Width, tmpImage.Height, PixelFormat.Format32bppArgb);

            // create a graphics instance to draw the original image in the new one
            Rectangle rect = new Rectangle(0, 0, tmpImage.Width, tmpImage.Height);
            Graphics g = Graphics.FromImage(returnedImage);

            // create an image attribe to force a clearing of the alpha layer
            ImageAttributes imageAttributes = new ImageAttributes();
            float[][] colorMatrixElements = {
                        new float[] {1,0,0,0,0},
                        new float[] {0,1,0,0,0},
                        new float[] {0,0,1,0,0},
                        new float[] {0,0,0,0,0},
                        new float[] {0,0,0,1,1}};

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            // draw the original image 
            g.DrawImage(tmpImage, rect, 0, 0, tmpImage.Width, tmpImage.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            return returnedImage;
        }
        #endregion
    }
}
