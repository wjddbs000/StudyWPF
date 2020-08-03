namespace ThirdCaliburnApp.Helpers
{
    public class Commons
    {
        public static readonly string CONNSTRING =
            "Data Source=localhost;Port=3306;Database=testdb;uid=root;password=mysql_p@ssw0rd";

    }
    public class EmployeesTbl
    {
        public static readonly string SELECT_EMPLOYEES = "SELECT id, " +
                                                          "       EmpName, " +
                                                          "       Salary, " +
                                                          "       DeptName, " +
                                                          "       Destination " +
                                                          "  FROM employeestbl ";
        internal static string UPDATE_EMPLOYEE = "UPDATE employeestbl " +
                                                 "   SET " +
                                                 "       EmpName = @EmpName, " +
                                                 "       Salary = @Salary, " +
                                                 "       DeptName = @DeptName, " +
                                                 "       Destination = @Destination " +
                                                 " WHERE id = @id ";

        public static string INSERT_EMPLOYEE = "INSERT INTO employeestbl " +
                                               "           ( " +
                                               "            EmpName, " +
                                               "            Salary, " +
                                               "            DeptName, " +
                                               "            Destination " +
                                               "           ) " +
                                               "            VALUES " +
                                               "           ( " +
                                               "            @EmpName, " +
                                               "            @Salary, " +
                                               "            @DeptName, " +
                                               "            @Destination " +
                                               "           ) ";

        internal static string DELETE_EMPLOYEE = "DELETE FROM employeestbl " +
                                                 " WHERE id = @id ";
    }
}
