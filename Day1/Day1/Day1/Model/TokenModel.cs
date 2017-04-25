namespace Day1.Model
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}

//{ 
// "access_token": "eyJh...cmw"
// "expires_in": 300
//}