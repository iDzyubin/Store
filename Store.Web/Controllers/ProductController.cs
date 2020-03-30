using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Product;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController( IProductRepository productRepository, IMapper mapper )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create( ProductModel model )
        {
            if( !ModelState.IsValid )
            {
                return View( model );
            }

            var item = _mapper.Map<Product>( model );
            await _productRepository.InsertAsync( item );
            return View();
        }

        [HttpGet]
        public IActionResult Update() => View();

        [HttpPost]
        public async Task<IActionResult> Update( ProductModel model )
        {
            if( !ModelState.IsValid )
            {
                return View( model );
            }

            var item = _mapper.Map<Product>( model );
            await _productRepository.UpdateAsync( item );
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete( Guid id )
        {
            await _productRepository.DeleteAsync( id );
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get( Guid id )
        {
            var model = await _productRepository.GetAsync( id );
            return View( model );
        }
    }
}