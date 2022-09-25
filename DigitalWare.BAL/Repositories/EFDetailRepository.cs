using DigitalWare.Cross_cutting.Common;
using DigitalWare.Domain.Contrats;
using DigitalWare.Domain.Data;
using DigitalWare.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.DAL.Repositories
{
    public class EFDetailRepository: IDetailsRepository<Order_Detail>
    {
        private readonly ApplicationDbContext _context;
        readonly List<Order_Detail> list = new();

        public EFDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MessageResult<Order_Detail>> GetById(int id)
        {
            try
            {
                var details = await _context.Order_Detail.Where(p => p.OrderID == id).ToListAsync();

                return new MessageResult<Order_Detail>(error: false, responseMessage: "La información se ha cargado correctamente", details);
            }
            catch (Exception ex)
            {

                return new MessageResult<Order_Detail>(error: true, responseMessage: ex.Message, list);
            }
        }

        public async Task<MessageResult<Order_Detail>> PostDetail(int id, Order_Detail order)
        {
            
            try
            {
                order.OrderID = id;

                var obj = await _context.Order_Detail.FindAsync(order.OrderID, order.ProductID);

                if (obj != null)
                {
                    return new MessageResult<Order_Detail>(error: true, responseMessage: "Ya existe ese producto en la orden", list);
                }

                _context.Order_Detail.Add(order);
                await _context.SaveChangesAsync();

                return new MessageResult<Order_Detail>(error: false, responseMessage: "La información se ha cargado correctamente", list);
            }
            catch (Exception ex)
            {
                return new MessageResult<Order_Detail>(error: true, responseMessage: ex.Message, list);
            }
        }
    }
}
