using QRCoder;

namespace QRCodeGeneratorHelper.Helper.QRCodeGeneratorHelper
{
    public class QRCodeGeneratorHelper : IQRCodeGeneratorHelper
    {
        public byte[] GenerateQRCode(string text)
        {
            // throw new NotImplementedException();
            byte[] QRCode = new byte[0];
            if(!string.IsNullOrEmpty(text))
            {
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeData data = qRCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode bitmap = new BitmapByteQRCode(data);
                QRCode = bitmap.GetGraphic(20);
            }
            return QRCode;
        }
    }
}
