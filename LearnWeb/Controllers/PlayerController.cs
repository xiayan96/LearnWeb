using AutoMapper;
using LearnWeb.Entites;
using LearnWeb.Entites.Dtos;
using LearnWeb.Entites.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample.GameManagement.Contracts;

namespace LearnWeb.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;

        public PlayerController(IRepositoryWrapper repository,ILogger<PlayerController> logger,IMapper mapper) 
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPlayers([FromQuery] PlayerParameter parameter) 
        {
            try
            {
                var players =  _repository.Player.GetPlayers(parameter);

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(players.MetaData));

                var results =_mapper.Map<IEnumerable<PlayerDto>>(players);
                return Ok(results);
            }catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}",Name ="PlayerById")]
        public async Task<IActionResult> GetPlayerById(Guid id)
        {
            try
            {
                var players = await _repository.Player.GetPlayerById(id);

                if (players is null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<PlayerDto>(players);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}/character")]
        public async Task<IActionResult> GetPlayerWithCharacters(Guid id)
        {
            try
            {
                var players = await _repository.Player.GetPlayerWithCharacters(id);

                if (players is null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<PlayerWithCharactersDto>(players);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody]PlayerForCreationDto player)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("无效的请求数据");
                }

                var playerEntity = _mapper.Map<Player>(player);

               

                _repository.Player.Create(playerEntity);
                await _repository.Save();

                var createdPlayer = _mapper.Map<PlayerDto>(playerEntity);

                return CreatedAtRoute("PlayerById",new { id = createdPlayer.Id},createdPlayer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(Guid id,[FromBody] PlayerForUpdateDto player)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("无效的请求数据");
                }

                var playerEntity = await _repository.Player.GetPlayerById(id);
                if (playerEntity is null)
                {
                    return NotFound();
                }

                _mapper.Map(player,playerEntity);

                _repository.Player.Update(playerEntity);
                await _repository.Save();

                var createdPlayer = _mapper.Map<PlayerDto>(playerEntity);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            try
            {
              
                var player = await _repository.Player.GetPlayerWithCharacters(id);
                if (player is null)
                {
                    return BadRequest("该玩家不存在");
                }

                if (player.Characters.Any())
                {
                    return BadRequest("该玩家有关联人物角色，不能删除！");
                }

                _repository.Player.Delete(player);
                await _repository.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

    }
}
