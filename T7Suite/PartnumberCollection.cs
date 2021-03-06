using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace T7
{
    class PartnumberCollection
    {
        DataTable dt;
        private void AddPartNumber(string part, string my)
        {
            PartNumberConverter pnc = new PartNumberConverter();
            ECUInformation ecuinfo = new ECUInformation();
            ecuinfo = pnc.GetECUInfo(part, "");
            dt.Rows.Add(ecuinfo.Carmodel.ToString(), ecuinfo.Enginetype.ToString(), part, ecuinfo.Turbomodel.ToString(), ecuinfo.Isturbo.ToString(), ecuinfo.Bhp.ToString(), ecuinfo.Torque.ToString(), ecuinfo.Softwareversion, ecuinfo.EmissionVariant.ToString().Replace('_', ' ').Replace("x", " ").Replace("None", ""), my);

        }

        public DataTable GeneratePartNumberCollection()
        {
            dt = new DataTable();
            dt.Columns.Add("Carmodel");
            dt.Columns.Add("Enginetype");
            dt.Columns.Add("Partnumber");
            dt.Columns.Add("Turbomodel");
            dt.Columns.Add("Turbo");
            dt.Columns.Add("Power");
            dt.Columns.Add("Torque");
            dt.Columns.Add("SoftwareVersion");
            dt.Columns.Add("EmissionVariant");
            dt.Columns.Add("Makeyear");

            AddPartNumber("5169446", "2001");
            AddPartNumber("5387923", "2001-2002");
            AddPartNumber("5388459", "2002-2003");
            AddPartNumber("5383930", "2002-2003");
            AddPartNumber("5383617", "2001-2002");
            AddPartNumber("5387931", "2001-2003");
            AddPartNumber("5383625", "2001-2003");
            AddPartNumber("5387949", "2001");
            AddPartNumber("5388467", "2002-2003");
            AddPartNumber("5383955", "2002-2003");
            AddPartNumber("5383633", "2001");
            AddPartNumber("5387956", "2001");
            AddPartNumber("5383641", "2001");
            AddPartNumber("5387964", "2001-2003");
            AddPartNumber("5383658", "2001-2003");
            AddPartNumber("5381587", "2001-2003");
            AddPartNumber("5380423", "2001");
            AddPartNumber("5169719", "2001");
            AddPartNumber("5387972", "2001-2003");
            AddPartNumber("5383666", "2001-2003");
            AddPartNumber("5381595", "2001-2003");
            AddPartNumber("5380415", "2001");
            AddPartNumber("5388228", "2000");
            AddPartNumber("5383427", "2000");
            AddPartNumber("5388236", "2000");
            AddPartNumber("5383419", "2000");
            AddPartNumber("5388244", "2000");
            AddPartNumber("5387980", "2001");
            AddPartNumber("5388426", "2002-2003");
            AddPartNumber("5383922", "2002-2003");
            AddPartNumber("5383435", "2000");
            AddPartNumber("5383674", "2001");
            AddPartNumber("5387998", "2001-2003");
            AddPartNumber("5383682", "2001-2003");
            AddPartNumber("5388004", "2001-2003");
            AddPartNumber("5383690", "2001-2003");
            AddPartNumber("5388251", "2000");
            AddPartNumber("5383450", "2000");
            AddPartNumber("5388269", "2000");
            AddPartNumber("5383443", "2000");
            AddPartNumber("5388277", "2000");
            AddPartNumber("5388012", "2001");
            AddPartNumber("5388434", "2002-2003");
            AddPartNumber("5383948", "2002-2003");
            AddPartNumber("5383468", "2000");
            AddPartNumber("5383708", "2001");
            AddPartNumber("5381504", "2003");
            AddPartNumber("5383278", "1999");
            AddPartNumber("5388285", "2000");
            AddPartNumber("5383476", "2000");
            AddPartNumber("5388293", "2000");
            AddPartNumber("5388046", "2001");
            AddPartNumber("5388442", "2002");
            AddPartNumber("5383914", "2002");
            AddPartNumber("5383484", "2000");
            AddPartNumber("5383732", "2001");
            AddPartNumber("5383286", "1999");
            AddPartNumber("5383294", "1998-2000");
            AddPartNumber("5383328", "1998-2000");
            AddPartNumber("55569107", "2007");
            AddPartNumber("55566754", "2007");
            AddPartNumber("55566757", "2006");
            AddPartNumber("55565638", "2007");
            AddPartNumber("55564143", "2007");
            AddPartNumber("55564014", "2006");
            AddPartNumber("55563620", "2007");
            AddPartNumber("55563379", "2006");
            AddPartNumber("55562537", "2005-2006");
            AddPartNumber("55562425", "2005-2006");
            AddPartNumber("55562028", "2005");
            AddPartNumber("55561307", "2005");
            AddPartNumber("55569108", "2007");
            AddPartNumber("55566755", "2007");
            AddPartNumber("55566758", "2006");
            AddPartNumber("55565639", "2007");
            AddPartNumber("55564144", "2007");
            AddPartNumber("55564013", "2006");
            AddPartNumber("55563621", "2007");
            AddPartNumber("55563378", "2006");
            AddPartNumber("55563250", "2006");
            AddPartNumber("55569108", "2008-2009");
            AddPartNumber("55566755", "2008-2009");
            AddPartNumber("55565639", "2008-2009");
            AddPartNumber("55564144", "2008-2009");
            AddPartNumber("55563621", "2008-2009");
            AddPartNumber("5388533", "2005");
            AddPartNumber("5388053", "2001");
            AddPartNumber("5387477", "2005");
            AddPartNumber("5387618", "2002");
            AddPartNumber("5386792", "2004");
            AddPartNumber("5386941", "2003");
            AddPartNumber("5384946", "2005");
            AddPartNumber("5386487", "2004");
            AddPartNumber("5386057", "2003");
            AddPartNumber("5386214", "2002");
            AddPartNumber("5385554", "2004");
            AddPartNumber("5385356", "2003");
            AddPartNumber("5385190", "2003");
            AddPartNumber("5384128", "2003");
            AddPartNumber("5384326", "2002");
            AddPartNumber("5383740", "2001");
            AddPartNumber("5388566", "2005");
            AddPartNumber("5388079", "2001");
            AddPartNumber("5387584", "2005");
            AddPartNumber("5387782", "2002");
            AddPartNumber("5386826", "2004");
            AddPartNumber("5386974", "2003");
            AddPartNumber("5384961", "2005");
            AddPartNumber("5386503", "2004");
            AddPartNumber("5385968", "2003");
            AddPartNumber("5386131", "2002");
            AddPartNumber("5385661", "2004");
            AddPartNumber("5385372", "2003");
            AddPartNumber("5384144", "2003");
            AddPartNumber("5384342", "2002");
            AddPartNumber("5383765", "2001");
            AddPartNumber("5388541", "2005");
            AddPartNumber("5387469", "2005");
            AddPartNumber("5387634", "2002");
            AddPartNumber("5386800", "2004");
            AddPartNumber("5386958", "2003");
            AddPartNumber("5384920", "2005");
            AddPartNumber("5386479", "2004");
            AddPartNumber("5386073", "2003");
            AddPartNumber("5386230", "2002");
            AddPartNumber("5385539", "2004");
            AddPartNumber("5385398", "2003");
            AddPartNumber("5385232", "2003");
            AddPartNumber("5384169", "2003");
            AddPartNumber("5384300", "2002");
            AddPartNumber("5388574", "2005");
            AddPartNumber("5387576", "2005");
            AddPartNumber("5387774", "2002");
            AddPartNumber("5386834", "2004");
            AddPartNumber("5386982", "2003");
            AddPartNumber("5384938", "2005");
            AddPartNumber("5386495", "2004");
            AddPartNumber("5385984", "2003");
            AddPartNumber("5386248", "2002");
            AddPartNumber("5385547", "2004");
            AddPartNumber("5385406", "2003");
            AddPartNumber("5384177", "2003");
            AddPartNumber("5384318", "2002");
            AddPartNumber("5388558", "2005");
            AddPartNumber("5388061", "2001");
            AddPartNumber("5387485", "2005");
            AddPartNumber("5387626", "2002");
            AddPartNumber("5386818", "2004");
            AddPartNumber("5386966", "2003");
            AddPartNumber("5384953", "2005");
            AddPartNumber("5386461", "2004");
            AddPartNumber("5386040", "2003");
            AddPartNumber("5386156", "2002");
            AddPartNumber("5385562", "2004");
            AddPartNumber("5385364", "2003");
            AddPartNumber("5385208", "2003");
            AddPartNumber("5384136", "2003");
            AddPartNumber("5384334", "2002");
            AddPartNumber("5383757", "2001");
            AddPartNumber("5388582", "2005");
            AddPartNumber("5388087", "2001");
            AddPartNumber("5387592", "2005");
            AddPartNumber("5387790", "2002");
            AddPartNumber("5386842", "2004");
            AddPartNumber("5386990", "2003");
            AddPartNumber("5384979", "2005");
            AddPartNumber("5386511", "2004");
            AddPartNumber("5385976", "2003");
            AddPartNumber("5386123", "2002");
            AddPartNumber("5385679", "2004");
            AddPartNumber("5385380", "2003");
            AddPartNumber("5384151", "2003");
            AddPartNumber("5384359", "2002");
            AddPartNumber("5383773", "2001");
            AddPartNumber("5384748", "1998-2000");
            AddPartNumber("5383302", "1998-2000");
            AddPartNumber("5383310", "1999-2000");
            AddPartNumber("55569098", "2008-2009");
            AddPartNumber("55569100", "2007");
            AddPartNumber("55564145", "2008-2009");
            AddPartNumber("55564147", "2007");
            AddPartNumber("55563142", "2007");
            AddPartNumber("55563144", "2008-2009");
            AddPartNumber("55561754", "2006");
            AddPartNumber("55569099", "2008-2009");
            AddPartNumber("55569111", "2007");
            AddPartNumber("55567768", "2007");
            AddPartNumber("55564146", "2008-2009");
            AddPartNumber("55564149", "2007");
            AddPartNumber("55563140", "2007");
            AddPartNumber("55563141", "2008-2009");
            AddPartNumber("55567767", "2006");
            AddPartNumber("55561756", "2006");
            AddPartNumber("55569098", "2007");
            AddPartNumber("55564145", "2007");
            AddPartNumber("55563144", "2007");
            AddPartNumber("55561759", "2006");
            AddPartNumber("55569099", "2007");
            AddPartNumber("55564146", "2007");
            AddPartNumber("55563141", "2007");
            AddPartNumber("55561761", "2006");
            AddPartNumber("55569101", "2007-2009");
            AddPartNumber("55564148", "2007-2009");
            AddPartNumber("55563145", "2007-2009");
            AddPartNumber("55560236", "2006");
            AddPartNumber("55569102", "2007-2009");
            AddPartNumber("55564150", "2007-2009");
            AddPartNumber("55563143", "2007-2009");
            AddPartNumber("55560248", "2006");
            AddPartNumber("5388301", "2000");
            AddPartNumber("5383336", "1998-2000");
            AddPartNumber("5383492", "2000");
            AddPartNumber("55569109", "2007-2009");
            AddPartNumber("55566756", "2007-2009");
            AddPartNumber("55565640", "2007-2009");
            AddPartNumber("55564758", "2007-2009");
            AddPartNumber("55564142", "2007-2009");
            AddPartNumber("55563622", "2007-2009");
            AddPartNumber("5388095", "2001");
            AddPartNumber("5383781", "2001");
            AddPartNumber("55559994", "2005");
            AddPartNumber("55559497", "2005");
            AddPartNumber("5388590", "2005");
            AddPartNumber("5387493", "2005");
            AddPartNumber("5386859", "2004");
            AddPartNumber("5387006", "2003");
            AddPartNumber("5384995", "2005");
            AddPartNumber("5386420", "2004");
            AddPartNumber("5386065", "2003");
            AddPartNumber("5385588", "2004");
            AddPartNumber("5385422", "2003");
            AddPartNumber("5385265", "2003");
            AddPartNumber("5384193", "2003");
            AddPartNumber("5388137", "2001");
            AddPartNumber("5387808", "2002");
            AddPartNumber("5387022", "2003");
            AddPartNumber("5385992", "2003");
            AddPartNumber("5386149", "2002");
            AddPartNumber("5385414", "2003");
            AddPartNumber("5384185", "2003");
            AddPartNumber("5384367", "2002");
            AddPartNumber("5383807", "2001");
            AddPartNumber("5388103", "2001");
            AddPartNumber("5387642", "2002");
            AddPartNumber("5386172", "2002");
            AddPartNumber("5384375", "2002");
            AddPartNumber("5383799", "2001");
            AddPartNumber("5388608", "2005");
            AddPartNumber("5387600", "2005");
            AddPartNumber("5386867", "2004");
            AddPartNumber("5385018", "2005");
            AddPartNumber("5386529", "2004");
            AddPartNumber("5383203", "2004");
            AddPartNumber("5388111", "2001");
            AddPartNumber("5383815", "2001");
            AddPartNumber("55559996", "2005");
            AddPartNumber("55559499", "2005");
            AddPartNumber("5388616", "2005");
            AddPartNumber("5388129", "2001");
            AddPartNumber("5387501", "2005");
            AddPartNumber("5387659", "2002");
            AddPartNumber("5386875", "2004");
            AddPartNumber("5387014", "2003");
            AddPartNumber("5385000", "2005");
            AddPartNumber("5386412", "2004");
            AddPartNumber("5386081", "2003");
            AddPartNumber("5386206", "2002");
            AddPartNumber("5385596", "2004");
            AddPartNumber("5385430", "2003");
            AddPartNumber("5385273", "2003");
            AddPartNumber("5384201", "2003");
            AddPartNumber("5384383", "2002");
            AddPartNumber("5383823", "2001");
            AddPartNumber("5384755", "1998-1999");
            AddPartNumber("5383344", "1998-1999");
            AddPartNumber("5383351", "1999");
            AddPartNumber("55569103", "2007-2009");
            AddPartNumber("55564151", "2007-2009");
            AddPartNumber("55563146", "2007-2009");
            AddPartNumber("55560237", "2006");
            AddPartNumber("55569104", "2007-2009");
            AddPartNumber("55564152", "2007-2009");
            AddPartNumber("55563147", "2007-2009");
            AddPartNumber("55560238", "2006");
            AddPartNumber("5388319", "2000");
            AddPartNumber("5383518", "2000");
            AddPartNumber("5388327", "2000");
            AddPartNumber("5383500", "2000");
            AddPartNumber("5388335", "2000");
            AddPartNumber("5383526", "2000");
            AddPartNumber("55559995", "2005");
            AddPartNumber("55559498", "2005");
            AddPartNumber("5388624", "2005");
            AddPartNumber("5388343", "2000");
            AddPartNumber("5388145", "2001");
            AddPartNumber("5384987", "2005");
            AddPartNumber("5387667", "2002");
            AddPartNumber("5387030", "2003");
            AddPartNumber("5386016", "2003");
            AddPartNumber("5386164", "2002");
            AddPartNumber("5385570", "2004");
            AddPartNumber("5385448", "2003");
            AddPartNumber("5385281", "2003");
            AddPartNumber("5385109", "2003");
            AddPartNumber("5384219", "2003");
            AddPartNumber("5384391", "2002");
            AddPartNumber("5383534", "2000");
            AddPartNumber("5383831", "2001");
            AddPartNumber("5383245", "2002");
            AddPartNumber("55560239", "2006");
            AddPartNumber("5388350", "2000");
            AddPartNumber("5383542", "2000");
            AddPartNumber("5383369", "1998-1999");
            AddPartNumber("5383377", "1998-1999");
            AddPartNumber("55559999", "2005");
            AddPartNumber("55559502", "2005");
            AddPartNumber("5388632", "2005");
            AddPartNumber("5387543", "2005");
            AddPartNumber("5386883", "2004");
            AddPartNumber("5386651", "2005");
            AddPartNumber("5386552", "2004");
            AddPartNumber("55559998", "2005");
            AddPartNumber("55559501", "2005");
            AddPartNumber("5388640", "2005");
            AddPartNumber("5387550", "2005");
            AddPartNumber("5386891", "2004");
            AddPartNumber("5386669", "2005");
            AddPartNumber("5386586", "2004");
            AddPartNumber("55569115", "2007-2008");
            AddPartNumber("55564157", "2007-2008");
            AddPartNumber("55563148", "2007-2008");
            AddPartNumber("55560240", "2006");
            AddPartNumber("55569114", "2007-2008");
            AddPartNumber("55564158", "2007-2008");
            AddPartNumber("55563149", "2007-2008");
            AddPartNumber("55560241", "2006");
            AddPartNumber("55559997", "2005");
            AddPartNumber("55559500", "2005");
            AddPartNumber("5388657", "2005");
            AddPartNumber("5388525", "2004");
            AddPartNumber("5387568", "2005");
            AddPartNumber("5386909", "2004");
            AddPartNumber("5386677", "2005");
            AddPartNumber("5386610", "2004");
            AddPartNumber("55569113", "2007-2008");
            AddPartNumber("55564156", "2007-2008");
            AddPartNumber("55563150", "2007-2008");
            AddPartNumber("55561856", "2006");
            AddPartNumber("5388152", "2001");
            AddPartNumber("5383849", "2001");
            AddPartNumber("55563632", "2003");
            AddPartNumber("55563633", "2004");
            AddPartNumber("55563634", "2005");
            AddPartNumber("55560000", "2005");
            AddPartNumber("55559503", "2005");
            AddPartNumber("5388665", "2005");
            AddPartNumber("5386917", "2004");
            AddPartNumber("5385034", "2005");
            AddPartNumber("5386446", "2004");
            AddPartNumber("5386107", "2003");
            AddPartNumber("5385752", "2003");
            AddPartNumber("5384227", "2003");
            AddPartNumber("5387527", "2005");
            AddPartNumber("5387048", "2003");
            AddPartNumber("5385612", "2004");
            AddPartNumber("5385455", "2003");
            AddPartNumber("5385299", "2003");
            AddPartNumber("55563630", "2002");
            AddPartNumber("5387675", "2002");
            AddPartNumber("5386313", "2002");
            AddPartNumber("5385695", "2002");
            AddPartNumber("5384409", "2002");
            AddPartNumber("55563631", "2002");
            AddPartNumber("5387709", "2002");
            AddPartNumber("5386271", "2002");
            AddPartNumber("5385711", "2002");
            AddPartNumber("5384540", "2002");
            AddPartNumber("5388160", "2001");
            AddPartNumber("5383856", "2001");
            AddPartNumber("55560001", "2005");
            AddPartNumber("55559504", "2005");
            AddPartNumber("5388673", "2005");
            AddPartNumber("5388178", "2001");
            AddPartNumber("5387535", "2005");
            AddPartNumber("5386925", "2004");
            AddPartNumber("5387055", "2003");
            AddPartNumber("5385042", "2005");
            AddPartNumber("5386453", "2004");
            AddPartNumber("5386099", "2003");
            AddPartNumber("5385745", "2003");
            AddPartNumber("5385620", "2004");
            AddPartNumber("5385463", "2003");
            AddPartNumber("5385307", "2003");
            AddPartNumber("5384235", "2003");
            AddPartNumber("5383864", "2001");
            AddPartNumber("5387683", "2002");
            AddPartNumber("5386297", "2002");
            AddPartNumber("5385687", "2002");
            AddPartNumber("5384417", "2002");
            AddPartNumber("5387717", "2002");
            AddPartNumber("5386289", "2002");
            AddPartNumber("5385729", "2002");
            AddPartNumber("5384557", "2002");
            AddPartNumber("55569106", "2007-2009");
            AddPartNumber("55564155", "2007-2009");
            AddPartNumber("55563151", "2007-2009");
            AddPartNumber("55561854", "2006");
            AddPartNumber("55560243", "2006");
            AddPartNumber("55569105", "2007-2009");
            AddPartNumber("55564154", "2007-2009");
            AddPartNumber("55563152", "2007-2009");
            AddPartNumber("55561853", "2006");
            AddPartNumber("5388368", "2000");
            AddPartNumber("5383559", "2000");
            AddPartNumber("5388376", "2000");
            AddPartNumber("5383567", "2000");
            AddPartNumber("55560002", "2005");
            AddPartNumber("55559505", "2005");
            AddPartNumber("5388681", "2005");
            AddPartNumber("5388384", "2000");
            AddPartNumber("5388186", "2001");
            AddPartNumber("5387519", "2005");
            AddPartNumber("5386933", "2004");
            AddPartNumber("5387063", "2003");
            AddPartNumber("5385026", "2005");
            AddPartNumber("5386438", "2004");
            AddPartNumber("5386115", "2003");
            AddPartNumber("5385737", "2003");
            AddPartNumber("5385604", "2004");
            AddPartNumber("5385471", "2003");
            AddPartNumber("5385315", "2003");
            AddPartNumber("5385083", "2003");
            AddPartNumber("5384243", "2003");
            AddPartNumber("5383575", "2000");
            AddPartNumber("5383872", "2001");
            AddPartNumber("5387691", "2002");
            AddPartNumber("5386305", "2002");
            AddPartNumber("5385703", "2002");
            AddPartNumber("5384425", "2002");
            AddPartNumber("5383252", "2002");
            AddPartNumber("55570653", "2007-2009");
            AddPartNumber("55569110", "2008-2009");
            AddPartNumber("55569112", "2007-2009");
            AddPartNumber("55567334", "2008-2009");
            AddPartNumber("55565942", "2008-2009");
            AddPartNumber("55564153", "2007-2009");
            AddPartNumber("55563153", "2007");
            AddPartNumber("55561852", "2006");
            AddPartNumber("5388392", "2000");
            AddPartNumber("5383583", "2000");
            AddPartNumber("5388194", "2001");
            AddPartNumber("5387071", "2003");
            AddPartNumber("5386032", "2003");
            AddPartNumber("5385489", "2003");
            AddPartNumber("5385323", "2003");
            AddPartNumber("5384250", "2003");
            AddPartNumber("5383880", "2001");
            AddPartNumber("5387725", "2002");
            AddPartNumber("5386222", "2002");
            AddPartNumber("5384433", "2002");
            AddPartNumber("5387758", "2002");
            AddPartNumber("5386263", "2002");
            AddPartNumber("5384565", "2002");
            AddPartNumber("5388202", "2001");
            AddPartNumber("5387089", "2003");
            AddPartNumber("5386024", "2003");
            AddPartNumber("5385497", "2003");
            AddPartNumber("5385331", "2003");
            AddPartNumber("5384268", "2003");
            AddPartNumber("5383898", "2001");
            AddPartNumber("5387733", "2002");
            AddPartNumber("5386180", "2002");
            AddPartNumber("5384441", "2002");
            AddPartNumber("5387766", "2002");
            AddPartNumber("5386255", "2002");
            AddPartNumber("5384573", "2002");
            AddPartNumber("5383385", "1998-2000");
            AddPartNumber("5388400", "2000");
            AddPartNumber("5383591", "2000");
            AddPartNumber("5388418", "2000");
            AddPartNumber("5388210", "2001");
            AddPartNumber("5387097", "2003");
            AddPartNumber("5386008", "2003");
            AddPartNumber("5385505", "2003");
            AddPartNumber("5385349", "2003");
            AddPartNumber("5385091", "2003");
            AddPartNumber("5384276", "2003");
            AddPartNumber("5383609", "2000");
            AddPartNumber("5383906", "2001");
            AddPartNumber("5387741", "2002");
            AddPartNumber("5386198", "2002");
            AddPartNumber("5384458", "2002");
            AddPartNumber("5383260", "2002");
            AddPartNumber("5383393", "1998-1999");
            AddPartNumber("5165113", "1999");
            AddPartNumber("4571725", "1999");
            AddPartNumber("5383401", "1999-2000");
            AddPartNumber("5166368", "1999-2000");
            AddPartNumber("5380860", "");
            AddPartNumber("5381249", "");
            AddPartNumber("5380522", "");
            AddPartNumber("5380514", "");
            AddPartNumber("5380506", "");
            AddPartNumber("5380498", "");
            AddPartNumber("5380845", "");
            AddPartNumber("5380852", "");
            AddPartNumber("5380779", "");
            AddPartNumber("5380803", "");
            AddPartNumber("5381223", "");
            AddPartNumber("5380597", "");
            AddPartNumber("5380589", "");
            AddPartNumber("5380381", "");
            AddPartNumber("5380571", "");
            AddPartNumber("5380878", "");
            AddPartNumber("5381389", "");
            AddPartNumber("5381298", "");
            AddPartNumber("5381322", "");
            AddPartNumber("5380563", "");
            AddPartNumber("5381421", "");
            AddPartNumber("5381355", "");
            AddPartNumber("5380829", "");
            AddPartNumber("5380811", "");
            AddPartNumber("5380555", "");
            AddPartNumber("5380399", "");
            AddPartNumber("5380548", "");
            AddPartNumber("5381405", "");
            AddPartNumber("5381413", "");
            AddPartNumber("5380530", "");
            AddPartNumber("5381397", "");
            AddPartNumber("5381272", "");
            AddPartNumber("5380944", "");
            AddPartNumber("5380951", "");
            AddPartNumber("5380787", "");
            AddPartNumber("5381363", "");
            AddPartNumber("5380969", "");
            AddPartNumber("5381256", "");
            AddPartNumber("5380837", "");
            AddPartNumber("5380795", "");
            AddPartNumber("5380449", "");
            AddPartNumber("5380431", "");
            AddPartNumber("5381280", "");
            AddPartNumber("5381348", "");
            AddPartNumber("5381330", "");
            AddPartNumber("5380480", "");
            AddPartNumber("5380472", "");
            AddPartNumber("5381231", "");
            AddPartNumber("5381264", "");
            AddPartNumber("5380464", "");
            AddPartNumber("5381371", "");
            AddPartNumber("5381207", "");
            AddPartNumber("5381314", "");
            AddPartNumber("5380456", "");
            AddPartNumber("5381306", "");
            AddPartNumber("5381215", "");
            AddPartNumber("5169677", "");
            AddPartNumber("5169693", "");

            AddPartNumber("5168646", "");
            AddPartNumber("5381728", "");
            AddPartNumber("5381843", "");
            AddPartNumber("5381603", "2001");

            return dt;
        }
    }
}
