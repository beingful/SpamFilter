﻿using System;
using System.Collections.Generic;

namespace MailService.DBModels
{
    public partial class Bernoulli
    {
        public Bernoulli() => Models = new HashSet<Model>();

        public Guid Id { get; set; }
        public int Spam { get; set; }
        public int NotSpam { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}