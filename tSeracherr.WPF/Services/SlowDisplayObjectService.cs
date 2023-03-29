using System.Threading.Tasks;

namespace tSeracherr.WPF.Services
{
    internal static class SlowDisplayObjectService
    {    
        public static async Task SlowDisplay(object obj, object borderOpacity, object printObj)
        {
            await Task.Run(async () =>
            {
                for (double i = 0; i < 1; i+=0.1)
                {
                    borderOpacity = i;
                    await Task.Delay(50);
                }

                printObj = obj;
                await Task.Delay(5000);

                for (double i = 1; i > 0.0; i -= 0.1)
                {
                    borderOpacity = i;
                    await Task.Delay(50);
                }
            });
        }
    }
}
