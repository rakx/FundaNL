using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FundaNLTask.Models
{
    public class Metadata
    {
        public string ObjectType { get; set; }
        public string Omschrijving { get; set; }
        public string Titel { get; set; }
    }

    public class ObjectViewModel
    {
        public string AangebodenSindsTekst { get; set; }
        public DateTime AanmeldDatum { get; set; }
        //public object AantalBeschikbaar { get; set; }
        public int AantalKamers { get; set; }
        //public object AantalKavels { get; set; }
        public string Aanvaarding { get; set; }
        public string Adres { get; set; }
        public int Afstand { get; set; }
        public string BronCode { get; set; }
        public IList<object> ChildrenObjects { get; set; }
        //public object DatumAanvaarding { get; set; }
        //public object DatumOndertekeningAkte { get; set; }
        public string Foto { get; set; }
        public string FotoLarge { get; set; }
        public string FotoLargest { get; set; }
        public string FotoMedium { get; set; }
        public string FotoSecure { get; set; }
        //public object GewijzigdDatum { get; set; }
        public int GlobalId { get; set; }
        public string GroupByObjectType { get; set; }
        public bool Heeft360GradenFoto { get; set; }
        public bool HeeftBrochure { get; set; }
        public bool HeeftOpenhuizenTopper { get; set; }
        public bool HeeftOverbruggingsgrarantie { get; set; }
        public bool HeeftPlattegrond { get; set; }
        public bool HeeftTophuis { get; set; }
        public bool HeeftVeiling { get; set; }
        public bool HeeftVideo { get; set; }
        //public object HuurPrijsTot { get; set; }
        //public object Huurprijs { get; set; }
        public object HuurprijsFormaat { get; set; }
        public string Id { get; set; }
        //public object InUnitsVanaf { get; set; }
        public bool IndProjectObjectType { get; set; }
        //public object IndTransactieMakelaarTonen { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsVerhuurd { get; set; }
        public bool IsVerkocht { get; set; }
        public bool IsVerkochtOfVerhuurd { get; set; }
        public int Koopprijs { get; set; }
        public string KoopprijsFormaat { get; set; }
        public int KoopprijsTot { get; set; }
        public int MakelaarId { get; set; }
        public string MakelaarNaam { get; set; }
        public string MobileURL { get; set; }
        //public object Note { get; set; }
        public IList<object> OpenHuis { get; set; }
        public int Oppervlakte { get; set; }
        public int Perceeloppervlakte { get; set; }
        public string Postcode { get; set; }
        //public Prijs Prijs { get; set; }
        public string PrijsGeformatteerdHtml { get; set; }
        public string PrijsGeformatteerdTextHuur { get; set; }
        public string PrijsGeformatteerdTextKoop { get; set; }
        public IList<string> Producten { get; set; }
        //public Project Project { get; set; }
        //public object ProjectNaam { get; set; }
        //public PromoLabel PromoLabel { get; set; }
        public DateTime PublicatieDatum { get; set; }
        public int PublicatieStatus { get; set; }
        //public object SavedDate { get; set; }
        public string Soortaanbod { get; set; }
        public int SoortAanbod { get; set; }
        //public object StartOplevering { get; set; }
        //public object TimeAgoText { get; set; }
        //public object TransactieAfmeldDatum { get; set; }
        //public object TransactieMakelaarId { get; set; }
        //public object TransactieMakelaarNaam { get; set; }
        public int TypeProject { get; set; }
        public string URL { get; set; }
        public string VerkoopStatus { get; set; }
        public double WGS84_X { get; set; }
        public double WGS84_Y { get; set; }
        public int WoonOppervlakteTot { get; set; }
        public int Woonoppervlakte { get; set; }
        public string Woonplaats { get; set; }
        public IList<int> ZoekType { get; set; }
}




    public class RootObject
    {
        public List<ObjectViewModel> objects { get; set; }
    }
    public class PropertyDetails
    {
        public string RealEstateAgentName { get; set; }
        public int PropertyCount { get; set; }
    }
}