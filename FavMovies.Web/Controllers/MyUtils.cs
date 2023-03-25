namespace testWebMVCApp.Controllers
{
    internal class MyUtils
    {
        private ICrypto _cryptoService;

        public MyUtils(ICrypto cryptoService)
        {
            _cryptoService = cryptoService;
        }
        internal void EncryptAString()
        {
            var encryptedText = _cryptoService.EncryptString("scooby doo we love you!");
        }
    }
}