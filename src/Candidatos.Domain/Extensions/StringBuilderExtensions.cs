using System;
using System.Collections.Generic;
using System.Text;

namespace Candidatos.Domain.Extensions
{
    public static class StringBuilderExtensions
    {

        public static StringBuilder Contains(this StringBuilder sb, string field, string value)
        {
            return sb.Append($" {field}:*{value}* ");
        }

        public static StringBuilder StartWith(this StringBuilder sb, string field, string value)
        {
            return sb.Append($" {field}:{value}* ");
        }

        public static StringBuilder And(this StringBuilder sb)
        {
            return sb.Append(" AND ");
        }

        public static StringBuilder Or(this StringBuilder sb)
        {
            return sb.Append(" OR ");
        }

    }
}
