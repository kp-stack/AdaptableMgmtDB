﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdaptableMgmtWPF.Program.UserControllers
{
    /// <summary>
    /// Interação lógica para Cart.xam
    /// </summary>
    public partial class Cart : UserControl
    {
        bool accesManager;


        public Cart(bool accesManager)
        {
            InitializeComponent(); this.accesManager = accesManager;
        }
    }
}
