using e_shop.Entities;
using System.ComponentModel.DataAnnotations;

namespace e_shop.Models
{
    public class ListPaymentDetailDTO
    {
        public int PaymentId { get; set; }

        public int UserId { get; set; }

        public string? CardOwnerName { get; set; }

        public string? Email { get; set; }


        public string? Address { get; set; }


        public string? CardNumber { get; set; }


        public string? ExpirationDate { get; set; }


        public string? SecurityCode { get; set; }

        public ListPaymentDetailDTO() { }

        public ListPaymentDetailDTO(PaymentDetail paymentDetail)
        {
            PaymentId = paymentDetail.PaymentDetailId;
            UserId = paymentDetail.UserId;
            CardOwnerName = paymentDetail.CardOwnerName;
            Email = paymentDetail.Email;
            Address = paymentDetail.Address;
            CardNumber = paymentDetail.CardNumber;
            ExpirationDate = paymentDetail.ExpirationDate;
            SecurityCode = paymentDetail.SecurityCode;
        }
    }

    public class CreatePaymentDetailDTO
    {
        public int UserId {  get; set; }

        [Required]
        public string? CardOwnerName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(16)]
        public string? CardNumber { get; set; }

        [Required]
        [MaxLength(5)]
        public string? ExpirationDate { get; set; }

        [Required]
        [MaxLength(3)]
        public string? SecurityCode { get; set; }
    }

    public class UpdatePaymentDetailDTO
    {
        public int PaymentId { get; set; }

        public string? CardOwnerName { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? CardNumber { get; set; }

        public string? ExpirationDate { get; set; }

        public string? SecurityCode { get; set; }
    }
}
