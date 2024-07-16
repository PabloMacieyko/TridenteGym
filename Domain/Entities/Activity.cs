
namespace Domain.Entities; 
public class Activity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Schedul { get; set; } = string.Empty;
    public Professor Professor { get; set; } = new();
    public IList<Client> ListClients { get; set; } = [];
    public int CupoMax { get; set; }

    public void clientRegistration(Client client)
    {
        if (ListClients.Count >= CupoMax)
            throw new Exception("Activity sin cupo");
        else
            ListClients.Add(client);
    }

    public void CancelClient(Client client)
    {
        var clientRegister = ListClients.FirstOrDefault(x => x.Id == client.Id);

        if (clientRegister != null)
            ListClients.Remove(clientRegister);
        else
            throw new Exception("Unregistered client");
    }
}
