using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TicketApp
{
    class Coupons
    {
        private List<string> couponsDB;
        private string filename;

        public Coupons(string filename)
        {
            this.filename = filename;
            couponsDB = Coupons.GetCouponList(filename);
        }

        public static List<string> GetCouponList(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("Coupon DB not found");

            return (List<string>)File.ReadLines(filename);
        }

        public static void SaveCouponsList(string filename, List<string> couponsList)
        {
            string text = "";
            foreach (string s in couponsList)
                text += s + Environment.NewLine;

            File.WriteAllText(filename, text);
        }

        public static bool ValidateCoupon(string coupon)
        {
            // length 1-8
            if (coupon.Length < 1 || coupon.Length > 8)
                return false;

            // only digits
            int result;
            if (!int.TryParse(coupon, out result))
                return false;

            return true;
        }

        public void SaveDB()
        {
            Coupons.SaveCouponsList(this.filename, this.couponsDB);
        }

        public void RefreshDB()
        {
            couponsDB = Coupons.GetCouponList(this.filename);
        }

        /// <summary>
        /// Checks if coupon exists in DB
        /// </summary>
        /// <returns>Returns true if coupon exists</returns>
        public bool CheckCoupon(string coupon)
        {
            if (couponsDB.Contains(coupon))
                return true;
            return false;
        }

        public void UseCoupon(string coupon)
        {
            couponsDB.Remove(coupon);
            SaveDB();
        }
    }


}
