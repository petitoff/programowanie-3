﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.Model;
using Prism.Events;

namespace CarMechanic.UI.Event
{
    internal class DeleteCustomerFromListEvent : PubSubEvent<Customer>
    {
    }
}
