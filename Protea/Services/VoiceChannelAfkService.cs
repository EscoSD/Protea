using System.Collections.Immutable;
using Protea.Data;
using Protea.Interfaces.Services;
using Protea.Models;

namespace Protea.Services;

public class VoiceChannelAfkService(IVoiceChannelTimerService vcTimerService) : IVoiceChannelAfkService
{
	private ImmutableList<UserGuildDto> _afkUsersToSave = ImmutableList<UserGuildDto>.Empty;
	
	public async Task UserSelfDeafened(UserGuildDto dto)
	{
		ImmutableInterlocked.Update(ref _afkUsersToSave,
			list => list.Add(dto));
		
		await Task.Delay(Constants.AfkTimerMillis);
		
		var afkUser = _afkUsersToSave.FirstOrDefault(user => user.UserId == dto.UserId);
		if (afkUser == null) return;

		ImmutableInterlocked.Update(ref _afkUsersToSave, list => list.Remove(afkUser));
		
		await vcTimerService.SaveUserTime(afkUser);
	}
	
	public void UserSelfUndeafened(UserGuildDto dto)
	{
		var afkUser = _afkUsersToSave.FirstOrDefault(user => user.UserId == dto.UserId);
		if (afkUser != null)
			ImmutableInterlocked.Update(ref _afkUsersToSave, list => list.Remove(afkUser));
		else
			vcTimerService.SaveVcEntry(dto);
	}
}
