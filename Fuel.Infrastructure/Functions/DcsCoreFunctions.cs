namespace Fuel.Infrastructure.Functions
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	static class DcsCoreFunctions
	{
		public const string GetRandom = @"
					-- FUNCTION: public.getrandom(integer, integer)

					CREATE OR REPLACE FUNCTION public.getrandom(
						upperlimit integer,
						lowerlimit integer)
					    RETURNS integer
					    LANGUAGE 'plpgsql'
					
					    COST 100
					    VOLATILE 
					AS $BODY$declare randomNum int;
					BEGIN
					 randomNum = ((random()*(upperLimit-lowerLimit))+lowerLimit)::int;
					 return randomNum;
					END;
					$BODY$;
		";
		public const string RemoveGetRandom = "DROP FUNCTION public.getrandom(integer, integer);";

		public const string GetRandomLicenseNo = @"
						-- FUNCTION: public.getrandomlicenseno()
						
						CREATE OR REPLACE FUNCTION public.getrandomlicenseno(
							)
						    RETURNS character varying
						    LANGUAGE 'plpgsql'
						
						    COST 100
						    VOLATILE 
						AS $BODY$
						declare
							license_no varchar(30);
							alphabets varchar(26) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
						BEGIN
							SELECT format('TN %s%s %s %s%s%s%s'
								 , a[1], a[2], substr(alphabets,(a[3]+1),1), a[4], a[5], a[6], a[7]) into license_no
							FROM  (
							   SELECT ARRAY (
								  SELECT trunc(random() * 10)::int
								  FROM   generate_series(1, 10)
								  ) AS a
							   ) sub;
							return license_no;
						END;
						$BODY$;
		";
		public const string ReomveGetRandomLicenseNo = "DROP FUNCTION public.getrandomlicenseno();";

		public const string GetRandomPhoneNumber = @"
						-- FUNCTION: public.getrandomphonenumber()
						
						CREATE OR REPLACE FUNCTION public.getrandomphonenumber(
							)
						    RETURNS character varying
						    LANGUAGE 'plpgsql'
						
						    COST 100
						    VOLATILE 
						AS $BODY$
						declare
							contact_no varchar(30);
						BEGIN
							SELECT format('(+91) 9%s%s%s%s%s%s%s%s%s'
								 , a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9]) into contact_no
							FROM  (
							   SELECT ARRAY (
								  SELECT trunc(random() * 10)::int
								  FROM   generate_series(1, 10)
								  ) AS a
							   ) sub;
							return contact_no;
						END;
						$BODY$;
		";
		public const string RemoveGetRandomPhoneNumber = "DROP FUNCTION public.getrandomphonenumber();";

		public const string GetRandomWithNumeric = @"
					-- FUNCTION: public.getrandomwithnumeric(numeric, numeric)
					
					CREATE OR REPLACE FUNCTION public.getrandomwithnumeric(
						""upperLimit"" numeric,
						""lowerLimit"" numeric)
					    RETURNS double precision
					
						LANGUAGE 'plpgsql'
					
					
						COST 100
					
						VOLATILE
					AS $BODY$declare randomNum double precision;
								BEGIN
								 randomNum = round(((random()::double precision * (""upperLimit"" - ""lowerLimit"")) + ""lowerLimit"")::numeric, 1)::double precision;
								return randomNum;
								END;$BODY$;
		";
		public const string RemoveGetRandomWithNumeric = "DROP FUNCTION public.getrandomwithnumeric(numeric, numeric);";
	}
}
