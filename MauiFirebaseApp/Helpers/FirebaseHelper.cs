using Firebase.Database;
using Firebase.Database.Query;
using MauiFirebaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFirebaseApp.Helpers
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient firebaseClient;
        
        public FirebaseHelper()
        {
            firebaseClient = new FirebaseClient("https://testproject-3d617-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Producto>> GetAllProductos()
        {

            var productos = await firebaseClient
                .Child("Productos")
                .OnceAsync<Producto>();

            return productos.Select(item => new Producto
            {
                Id = item.Key,
                Nombre = item.Object.Nombre,
                Descripcion = item.Object.Descripcion,
                Precio = item.Object.Precio,
            }).ToList();

        }

        public async Task addProducto(Producto producto)
        {
            await firebaseClient
                .Child("Productos")
                .PostAsync(producto);
        }

        public async Task UpdateProducto(string key, Producto producto)
        {
            await firebaseClient
                .Child("Productos")
                .PutAsync(producto);
        }

        public async Task DeleteProducto(string key)
        {
            await firebaseClient
                .Child("Productos")
                .Child(key)
                .DeleteAsync();
        }
    }
}
