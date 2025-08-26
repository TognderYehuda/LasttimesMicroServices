using AuctionService.Data;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly AuctionDbContext _auctionDb;
        private readonly IMapper _mapper;

        public AuctionController(AuctionDbContext auctionDb ,IMapper mapper)
        {
            _auctionDb = auctionDb;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuctionDto>>> GetAllAuctionAsync(){
            var auction = await _auctionDb.Auctions
                          .Include(x=>x.Item)
                          .OrderBy(o=>o.Item.Make).ToListAsync();

           return _mapper.Map<List<AuctionDto>>(auction);
        }


         [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDto>>GetAuctionByIdAsync(Guid id){
            var auction = await  _auctionDb.Auctions
                           .Include(x=>x.Item)
                         .FirstOrDefaultAsync(x=>x.Id == id);

              if(auction ==null)
              {
                 return NotFound();
              }
              

              return _mapper.Map<AuctionDto>(auction);
                          
        }

        [HttpPost]
        public async Task <ActionResult<AuctionDto>> CreateAuction(CreateAuctionDto createAuctionDto){
           
           var auction = _mapper.Map<Auction>(createAuctionDto);

           //TODO : add current use as seller 

           auction.Seller = "yehudat";

           _auctionDb.Auctions.Add(auction);


           var result = await _auctionDb.SaveChangesAsync() > 0;

          if(!result) return BadRequest("Server error");

          //TODO: need to chack , get error in the return 
        // return CreatedAtAction(nameof(GetAuctionByIdAsync),new {id= auction.Id} ,_mapper.Map<AuctionDto>(auction));

        return Ok(_mapper.Map<AuctionDto>(auction));



        }

      

        [HttpPut("{id}")]
        public async Task<ActionResult>UpdateAuction(Guid id , UpdateAuctionDto updateAuctionDto)
        {
           var auction = await _auctionDb.Auctions.Include(x=>x.Item)
                         .FirstOrDefaultAsync(x=>x.Id == id);

                 if(auction == null) return NotFound();   

                 //TODO: cheack seller  == username 

                 auction.Item.Make = updateAuctionDto.Make ?? auction.Item.Make;
                 auction.Item.Model = updateAuctionDto.Model ?? auction.Item.Model; 
                 auction.Item.Color = updateAuctionDto.Color ?? auction.Item.Color; 
                 auction.Item.Mileage = updateAuctionDto.Mileage ?? auction.Item.Mileage; 
                 auction.Item.Year = updateAuctionDto.Year ?? auction.Item.Year; 

                 var result = await _auctionDb.SaveChangesAsync() > 0 ;

                 if(result) return Ok();

                 return BadRequest("Problem in Update");
        
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuction(Guid id)
        {
            var auction = await _auctionDb.Auctions.FindAsync(id);

            if(auction == null) return NotFound();


            _auctionDb.Auctions.Remove(auction);

            var result = await _auctionDb.SaveChangesAsync() > 0;

            if(!result) return BadRequest("Intrnal Server error");

            return Ok();
                          
        }
    }
}
