using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string Cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(Cs);
            con.Open();
            try
            {
                Console.WriteLine("Connection Established");
                string rrr;
                do
                {
                    Console.WriteLine("Select For Option: 1.Create\n 2.Retrive\n 3.Update\n 4.Delete\n 5.proceedInsert\n");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Enter Student Id");
                            int S_Id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Student Name");
                            string S_Name = Console.ReadLine();
                            Console.WriteLine("Enter Student Email");
                            string S_Email = Console.ReadLine();
                            string insertQuery = "INSERT INTO Table_1(StuId,StuName,StuEmail) values(" + S_Id + ",'" + S_Name + "','" + S_Email + "')";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Data Inserted");
                            break;
                        case 2:
                            string displayQuery = "Select * from Table_1";
                            SqlCommand displayCommand = new SqlCommand(displayQuery, con);
                            SqlDataReader reader = displayCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                Console.WriteLine("id :" + reader.GetValue(0).ToString());
                                Console.WriteLine("name :" + reader.GetValue(1).ToString());
                                Console.WriteLine("email :" + reader.GetValue(2).ToString());
                            }
                            reader.Close();
                            break;
                        case 3:
                            Console.WriteLine("Enter Student Id");
                            int S_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Student Email");
                            string S_email = Console.ReadLine();
                            string updateQuery = "UPDATE Table_1 SET StuEmail =" + S_email + " Where StuId = '" + S_id + "'";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, con);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Data Updated");
                            break;
                        case 4:
                            Console.WriteLine("Enter Student Id");
                            int s_id = int.Parse(Console.ReadLine());
                            string deleteQuery = "Delete From Table_1 where StuId = " + s_id;
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, con);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Delete SucessFully");
                            break;
                        case 5:
                            Console.WriteLine("Enter Student Id");
                            int st_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Student Name");
                            string st_name = Console.ReadLine();
                            Console.WriteLine("Enter Student Email");
                            string st_email = Console.ReadLine();
                            SqlCommand proceedcmd = new SqlCommand("insertData", con);
                            proceedcmd.CommandType = CommandType.StoredProcedure;
                            proceedcmd.Parameters.AddWithValue("@StuId", st_id);
                            proceedcmd.Parameters.AddWithValue("@StuName", st_name);
                            proceedcmd.Parameters.AddWithValue("@StuEmail", st_email);
                            proceedcmd.ExecuteNonQuery();
                            Console.WriteLine("Data Inserted");
                            break;
                        default:
                            Console.WriteLine("Wrong Input");
                            break;
                    }
                    Console.WriteLine("Do you Want to Continue:");
                    Console.ReadKey();
                    rrr = Console.ReadLine();
                } while (rrr != "no");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            Console.ReadKey();
        }
    }
}