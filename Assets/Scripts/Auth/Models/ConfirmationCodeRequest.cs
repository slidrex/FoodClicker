public struct ConfirmationCodeRequest
{
    public string email { get; set; }

    public ConfirmationCodeRequest(string email)
    {
        this.email = email;
    }
}
