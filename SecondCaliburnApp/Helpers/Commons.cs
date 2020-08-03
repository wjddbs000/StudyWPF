namespace SecondCaliburnApp.Helpers
{
    class Commons
    {
        public static string strConnString = "Data Source=localhost;Port=3306;Database=testdb;uid=root;password=mysql_p@ssw0rd";

        public static string SELECTPEOPLEQUERY=
            "  SELECT firstname,lastname "+
            "    FROM peopletbl " + 
            "ORDER BY id ";

    }
}
