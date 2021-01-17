using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generateConsole
{
    class Program
    {
        private static string strConnection = "Data Source=localhost;Initial Catalog=hopital;User ID=sa;Password=sql";
        //private static string strConnection = "Data Source=10.4.169.201;Initial Catalog=DBGroupe2;User ID=MStJean;Password=sql";

        private static List<string> listeMaladie = new List<string>() { "Coronariennes", "Muscle cardiaque"
                , "Angor (ou angine de poitrine)","Infarctus du myocarde", "Cardiomyopathie", "", "Insuffisance cardiaque"
                , "valves cardiaques", "Endocardite", "Valvulopathies cardiaques", "péricarde", "Tumeur du cerveau",
                "leucémies", "carcinome hépatocellulaire", "cancer du larynx", "cancer de l'endomètre"
                , "maxillaire aiguë", "sphénoïdale aiguë", "Laryngite aiguë", "Laryngite obstructive aiguë (croup)" };

        private static List<string> allergie = new List<string>() { "Les arachides", "Le blé", "Les fruits de mer", "Les graines de sésame",
                "Le lait", "Les noix", "Les œufs", "Le soja", "Les sulfites", "La moutarde"};


        private static List<string> name = new List<string>() { "Brenda/Cox", "Judith/Phillips", "Joan/Hernandez", "Dorothy/Campbell", "Shirley/Gray", "Julie/Foster",
                "Ruth/Simmons", "Raymond/Gonzales", "Betty/Young", "Adam/Harris", "Steve/Morris", "Samuel/Perez", "Ann/Bell", "Judy/Miller", "Beverly/Parker"
                , "Marie/Powell", "Arthur/Diaz", "Joseph/Thompson", "Rachel/Wright", "Patrick/Bryant", "Lisa/Moore", "Joshua/Richardson", "Roger/Brown", "Tina/Adams", "Sara/Barnes",
                "Irene/Sanders", "Carol/Howard", "Steven/Williams", "Shawn/Anderson", " Shawn/Anderson", "Juan/Perry", "Kevin/Lewis", "Michelle/Reed", "Gary/James",
                "Bobby/Davis", "Harold/Griffin", "Lori/Torres", "Katherine/Hall", "Laura/Scott", "Henry/Ward", "Ronald/Bennett", "Jonathan/Price", "Andrew/Allen","Billy/Garcia","Bonnie/Rivera","Larry/Lopez",
                "Lois/Martin","Theresa/Edwards","Norma/Baker","Mary/Wilson","Annie/Ross","John/Brooks","Tammy/Carter","Maria/Evans","Jose/Russell","Linda/Sanchez","Rose/Smith","Janice/Taylor","Jeremy/Nelson",
                "Ryan/Johnson","Diana/Cook","Jeffrey/Stewart","Alice/Jackson","Barbara/Jones","Aaron/Robinson","Kathryn/Peterson","Heather/Murphy","Russell/Roberts","Christine/Thomas",
                "Lillian/Rogers","Helen/Cooper","Timothy/Butler","Pamela/Clark","Kathy/Hill","Fred/Jenkins","Alan/Martinez","Jesse/Collins","Wanda/Gonzalez","Anna/Alexander","Gerald/King",
                "Jimmy/Walker","Nancy/Long","Paula/Bailey","Doris/Coleman","Willie/Henderson","Benjamin/Patterson","Janet/Green","Rebecca/Washington","Bruce/Wood","Deborah/Watson",
                "Stephanie/Rodriguez","Richard/Hughes","Sarah/Flores","Justin/Mitchell","Ernest/White","Teresa/Lee","Amy/Kelly","Susan/Morgan","Charles/Turner", "jp/jf"};


        static void Main(string[] args)
        {

            Patient();


            Console.Read();
        }

        private static void Donneur()
        {
            SqlConnection cn = new SqlConnection(strConnection);
            cn.Open();

            for (int i = 1; i <= 100; i++)
            {
               
                //SqlCommand cmd = new SqlCommand("insert into [dbo].[Donneur] ([Code_Do], [Vivant_Do], [ADN_Do], [Allergie_Do], [Raison_Deces_Do], [Virus], [Groupe_Sanguin_Do], [Date_Transplant_Do], [Code_Patient])" +
                //   "values(@Code_Do, @Vivant_Do, @ADN_Do, @Allergie_Do, @Raison_Deces_Do, @Virus, @Groupe_Sanguin_Do, @Date_Transplant_Do, @Code_Patient)", cn);
                //cmd.Parameters.AddWithValue("@Code_Do", i);
                //cmd.Parameters.AddWithValue("@Vivant_Do", bit4);
                //cmd.Parameters.AddWithValue("@ADN_Do", bit5);
                //cmd.Parameters.AddWithValue("@Allergie_Do", i);
                //cmd.Parameters.AddWithValue("@Raison_Deces_Do", bit4);
                //cmd.Parameters.AddWithValue("@Virus", bit5);
                //cmd.Parameters.AddWithValue("@Groupe_Sanguin_Do", bit5);
                //cmd.Parameters.AddWithValue("@Date_Transplant_Do", bit5);
                //cmd.Parameters.AddWithValue("@Code_Patient", i);
                //cmd.ExecuteNonQuery();
            }
            cn.Close();

            Console.WriteLine("sucess");
        }

        private static void Patient()
        {
            SqlConnection cn = new SqlConnection(strConnection);
            cn.Open();

            Random random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                int randomNumber = random.Next(1000000, 9999999);

                int mois = random.Next(1, 12);
                int jour = random.Next(1, 29);
                int anne = random.Next(1930, 2010);

                int moist = random.Next(1, 12);
                int jourt = random.Next(1, 29);
                int annet = random.Next(2010, 2016);

                int bit1 = random.Next(0, 2);
                int bit2 = random.Next(0, 2);
                int bit3 = random.Next(0, 2);
                int bit4 = random.Next(0, 2);
                int bit5 = random.Next(0, 2);
                int bit6 = random.Next(0, 2);

                int c = random.Next(0, 2);

                String value = name[i - 1];
                Char delimiter = '/';
                String[] substrings = value.Split(delimiter);
                string prenom = substrings[0];
                string nom = substrings[1];

                string allergies = allergie[random.Next(allergie.Count - 1)];

                string maladie = listeMaladie[random.Next(listeMaladie.Count - 1)];

                SqlCommand cmd = new SqlCommand("insert into [dbo].[Patient] ([Code_Patient],[Nom_Patient],[Prenom_Patient]" +
                ",[NAS_Patient],[DateNaissance_Patient],[Allergie_Patient],[Maladie_Original_Patient],[Date_Transplant_Patient]" +
                ",[Coter_Transplant_Patient],[ABV_Patient],[Anergy_Patient],[PPD_Patient],[HbsAg_Patient],[CMV_Patient]" +
                ",[Transfusion_Patient],[VV_ByPass_Patient],[Antifib_Lytics_Patient]) " +

                "values(@Code_Patient, @Nom_Patient, @Prenom_Patient, @NAS_Patient, @DateNaissance_Patient, " +
                "@Allergie_Patient, @Maladie_Original_Patient, @Date_Transplant_Patient, @Coter_Transplant_Patient, " +
                "@ABV_Patient, @Anergy_Patient, @PPD_Patient, @HbsAg_Patient, @CMV_Patient, @Transfusion_Patient, @VV_ByPass_Patient, " +
                "@Antifib_Lytics_Patient)", cn);


                string dateNaissanceF = anne + "-" + jour + "-" + mois;
                string dateNaissanceA = anne + "-" + mois + "-" + jour;


                string dateTransfusionF = annet + "-" + jourt + "-" + moist;
                string dateTransfusionA = annet + "-" + moist + "-" + jourt;

                cmd.Parameters.AddWithValue("@Code_Patient", i);
                cmd.Parameters.AddWithValue("@Nom_Patient", nom);
                cmd.Parameters.AddWithValue("@Prenom_Patient", prenom);
                cmd.Parameters.AddWithValue("@NAS_Patient", randomNumber);
                cmd.Parameters.AddWithValue("@DateNaissance_Patient", dateNaissanceA);
                cmd.Parameters.AddWithValue("@Allergie_Patient", allergies);
                cmd.Parameters.AddWithValue("@Maladie_Original_Patient", maladie);
                cmd.Parameters.AddWithValue("@Date_Transplant_Patient", dateTransfusionA);

                char cote;
                if (c == 0)
                {
                    cote = 'd';
                }
                else
                {
                    cote = 'g';
                }

                cmd.Parameters.AddWithValue("@Coter_Transplant_Patient", cote);
                cmd.Parameters.AddWithValue("@ABV_Patient", i);
                cmd.Parameters.AddWithValue("@Anergy_Patient", GenerateName(15));
                cmd.Parameters.AddWithValue("@PPD_Patient", bit1);
                cmd.Parameters.AddWithValue("@HbsAg_Patient", bit2);
                cmd.Parameters.AddWithValue("@CMV_Patient", bit3);
                cmd.Parameters.AddWithValue("@Transfusion_Patient", i);
                cmd.Parameters.AddWithValue("@VV_ByPass_Patient", bit4);
                cmd.Parameters.AddWithValue("@Antifib_Lytics_Patient", bit5);

                cmd.ExecuteNonQuery();
            }
            cn.Close();

            Console.WriteLine("sucess");

        }

        private static Random r = new Random();
        public static string GenerateName(int len)
        {

            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }
    }
}
