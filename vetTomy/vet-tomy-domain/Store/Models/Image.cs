using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public int ProducServiceId { get; set; }
        public bool State { get; set; }
    }

    public class ImageBody
    {
        public string? Url { get; set; }
        public int ProducServiceId { get; set; }
        public bool State { get; set; }
        public static implicit operator Image(ImageBody body)
        {
            if (body == null) return null;
            return new Image
            {
                Id = 0,
                Url = body.Url,
                ProducServiceId = body.ProducServiceId,
                State = true,
            };
        }
    }
}
