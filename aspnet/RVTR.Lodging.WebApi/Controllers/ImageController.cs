using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Azure;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Azure.Storage.Blobs;
using System;
using Azure.Storage.Blobs.Models;

namespace RVTR.Lodging.WebApi.Controllers
{ 
    /// <summary>
    ///
    /// </summary>
    [ApiController]
    [EnableCors("public")]
    [ApiVersion("0.0")]
    [Route("rest/lodging/{version:apiVersion}/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> _logger;
        private readonly UnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor for the ImageController sets up logger and unitOfWork dependencies
        /// </summary>
        /// <param name="logger">The Logger</param>
        /// <param name="unitOfWork">The UnitOfWork</param>
        /// <param name="configuration">The Configuration</param>
        public ImageController(ILogger<ImageController> logger, UnitOfWork unitOfWork, IConfiguration configuration)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        /// <summary>
        /// Gets all the images in the blob storage
        /// </summary>
        /// <returns>The Image</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("blob"));

            // Get the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("images");
            
            var images = new List<BlobItem>();

            // List all blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                images.Add(blobItem);
                Console.WriteLine("\t" + blobItem.Name);
            }

            // BlobDownloadInfo download = await blobClient.DownloadAsync();

            // using (FileStream downloadFileStream = File.OpenWrite(downloadFilePath))
            // {
            //     await download.Content.CopyToAsync(downloadFileStream);
            //     downloadFileStream.Close();
            // }

            return Ok(images);
        }

    }
}