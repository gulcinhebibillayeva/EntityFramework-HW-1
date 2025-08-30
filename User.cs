namespace ADO_NET_03_Homework;

internal class User
{
    public int Id { get; set; }
    public string UserName { get; set; }

    public string Password { get; set; }

    public string FirstName {  get; set; }
    public string LastName { get; set; }

    public int Age {  get; set; }
    public bool Gender {  get; set; }=false;


    public override string ToString()
    {
        return $"\n{Id}{FirstName}{LastName}-{Age}, {Gender}\n";
    }


}
