using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Product;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с товарами
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Basic ctor.
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="mapper"></param>
        public ProductController( IProductRepository productRepository, IMapper mapper )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Страница со списком товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index() => View();

        /// <summary>
        /// Отрисовываем страницу добавления товара
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create() => View();

        /// <summary>
        /// Добавить товар
        /// </summary>
        /// <param name="model">Добавляемый товар</param>
        [HttpPost]
        public async Task<IActionResult> Create( ProductModel model )
        {
            if( !ModelState.IsValid )
            {
                return View( model );
            }

            var item = _mapper.Map<Product>( model );
            await _productRepository.InsertAsync( item );
            return RedirectToAction( "Index" );
        }

        /// <summary>
        /// Находим информацию об обновляемом товаре и отрисовываем страницу
        /// </summary>
        /// <param name="id">Обновляемый товар</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Update( Guid id )
        {
            var item = await _productRepository.GetAsync( id );
            var model = _mapper.Map<ProductModel>( item );
            return View( model );
        }

        /// <summary>
        /// Обновить информацию о товаре
        /// </summary>
        /// <param name="model">Обновленная информация о товаре</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update( ProductModel model )
        {
            if( !ModelState.IsValid )
            {
                return View( model );
            }

            var item = _mapper.Map<Product>( model );
            await _productRepository.UpdateAsync( item );
            return RedirectToAction( "Index" );
        }

        /// <summary>
        /// Удалить товар
        /// </summary>
        /// <param name="id">Удаляемый товар</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete( Guid id )
        {
            await _productRepository.DeleteAsync( id );
            return Ok();
        }
    }
}