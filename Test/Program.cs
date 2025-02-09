using Verzekeringen;

namespace Test
{
    public class Program
    {
        static void Main()
        {
            try
            {
                long l2 = 0;

                VerzMaatschappij oVM = VerzMaatschappij.GeefVM();
                //VerzMaatschappij oVM2 = VerzMaatschappij.GeefVM();			

                long l = oVM.OpenVerz(VerzType.Boot, 3000f);
                //oVM.SchadeMelden(l, true, 66.67f, "");

                l2 = oVM.OpenVerz();
                //oVM.SchadeMelden(l2, true, 481.55f, "Boompje");
                //oVM.SchadeMelden(l2, false, 200f, "paaltje");
                //oVM.SchadeMelden(l2, true, 99.95f, "");
                long l3 = oVM.OpenVerz(VerzType.Auto, 5000f);

                oVM.DrukAf();
                oVM.StartNieuwJaar(10);
                oVM.DrukAf();
                oVM.GroeiMee(l2);
                oVM.StartNieuwJaar(10);
                oVM.DrukAf();
                oVM.GroeiNietMee(l2);
                oVM.GroeiMee(l);
                oVM.StartNieuwJaar(5);
                oVM.DrukAf();

                //l =  oVM.OpenVerz();
                //oVM.SchadeMelden(l, false, 481.55f, "ongeluk");
                //oVM.SchadeMelden(l, true, 481.55f, "");

                //oVM.WijzigMaxBedrag(l2, 1500);
                //oVM.VerzOpheffen(l2);

                //oVM.DumpNaarScherm();

                //oVM.Reflect();

                //oVM.DrukAfSchade(90000000,0);

            }
            catch (TeveelMaatschappijenException s)
            {
                Console.WriteLine("{0}", s.GetMessage());
            }
            catch (SchadeTeHoogException s)
            {
                Console.WriteLine("{0}", s.GetMessage());
            }
            catch (SchadeOutOfBound s)
            {
                Console.WriteLine("{0}", s.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("foutje: {0}", e);
            }
        }
    }
}
