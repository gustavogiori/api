﻿using CrossCutting.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CrossCutting.Helpers
{
	public static class ExceptionDictionary
	{
		public static HttpStatusCode ConvertToHttpStatusCode(this Exception exception)
		{
			Dictionary<Type, HttpStatusCode> dict = GetExceptionDictionary();
			if (dict.ContainsKey(exception.GetType()))
			{
				return dict[exception.GetType()];
			}
			return dict[typeof(Exception)];
		}

		private static Dictionary<Type, HttpStatusCode> GetExceptionDictionary()
		{
			Dictionary<Type, HttpStatusCode> dict = new Dictionary<Type, HttpStatusCode>();
			dict[typeof(ResourceNotFoundException)] = HttpStatusCode.NotFound;
			dict[typeof(Exception)] = HttpStatusCode.InternalServerError;
			return dict;
		}
	}
}