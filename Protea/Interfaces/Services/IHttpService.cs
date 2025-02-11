namespace Protea.Interfaces.Services;

public interface IHttpService
{
	Task<string> GetCatUrlAsync();
	Task<string> GetDogUrlAsync();
}