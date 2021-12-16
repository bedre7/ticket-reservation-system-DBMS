--
-- PostgreSQL database dump
--

-- Dumped from database version 13.4
-- Dumped by pg_dump version 13.4

-- Started on 2021-12-16 16:50:09

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3202 (class 1262 OID 41411)
-- Name: OnlineBusReservation; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "OnlineBusReservation" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';


ALTER DATABASE "OnlineBusReservation" OWNER TO postgres;

\connect "OnlineBusReservation"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 248 (class 1255 OID 49963)
-- Name: addContactInformation(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."addContactInformation"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF NEW."email" NOT LIKE '%@%' THEN
            NEW."email"  
			:= CONCAT(NEW.email, 
			'@epixtravels.com');
    END IF;
    RETURN NEW;
END;
$$;


ALTER FUNCTION public."addContactInformation"() OWNER TO postgres;

--
-- TOC entry 252 (class 1255 OID 50026)
-- Name: addDriverTR1(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."addDriverTR1"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
	NEW."name" = LTRIM(NEW."name");
	NEW."surname" = LTRIM(NEW."surname");
    NEW."surname" = UPPER(NEW."surname");
    IF NEW."salary" < 4250 THEN
            RAISE EXCEPTION 'Salary should be greater than minimum wage - 4250₺';
    END IF;
    RETURN NEW;
END;
$$;


ALTER FUNCTION public."addDriverTR1"() OWNER TO postgres;

--
-- TOC entry 247 (class 1255 OID 49962)
-- Name: bringavailablebuses(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.bringavailablebuses() RETURNS text
    LANGUAGE plpgsql
    AS $$
DECLARE
	buses "Bus"%ROWTYPE;
   busPlateNo Text;
BEGIN
	busPlateNo := '';
	FOR buses IN SELECT * FROM "Bus"
	LEFT JOIN "Driver" ON "Bus"."plateNo" = "Driver"."plateNo"
	WHERE "driverID" IS NULL LOOP
        busPlateNo := busPlateNo || buses."plateNo" || E'\r\n';
    END LOOP;
	RETURN busPlateNo;
END;
$$;


ALTER FUNCTION public.bringavailablebuses() OWNER TO postgres;

--
-- TOC entry 249 (class 1255 OID 50020)
-- Name: calculateprice(integer, date); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.calculateprice(baseprice integer, birthdate date) RETURNS integer
    LANGUAGE plpgsql
    AS $$ 
DECLARE
	age INT;
	finalPrice INT;
BEGIN
	age := EXTRACT(year FROM age(current_date,birthdate));
	finalPrice := baseprice;
	
	IF getDiscountID(birthdate) = 1 THEN
        finalPrice := baseprice * 0.7;
	END IF;
	IF getDiscountID(birthdate) = 2 THEN
		finalPrice := basePrice * 0.8;
    END IF;
    RETURN finalPrice;
END;
$$;


ALTER FUNCTION public.calculateprice(baseprice integer, birthdate date) OWNER TO postgres;

--
-- TOC entry 233 (class 1255 OID 49979)
-- Name: controlStatus(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."controlStatus"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
	IF OLD."status" != 'Unbooked' THEN
           RAISE EXCEPTION 'Trip can not be deleted since it is already booked'; 
	ELSE
		UPDATE "Driver"
		SET "status" = 'Available'
		WHERE "Driver"."driverID" = OLD."driver";

		UPDATE "Bus"
		SET "status" = 'Available'
		WHERE "Bus"."plateNo" = OLD."bus";         
	END IF;
	 RETURN OLD;
END;
$$;


ALTER FUNCTION public."controlStatus"() OWNER TO postgres;

--
-- TOC entry 250 (class 1255 OID 50018)
-- Name: getdiscountid(date); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.getdiscountid(birthdate date) RETURNS integer
    LANGUAGE plpgsql
    AS $$ 
DECLARE
	discountID INT;
	age INT;
BEGIN
	age := EXTRACT(year FROM age(current_date,birthdate));
	discountID := 5;
	
	IF age < 24  THEN
        discountID := 1;
	END IF;
	IF age > 60 THEN
		discountID := 2;
    END IF;
    RETURN discountID;
END;
$$;


ALTER FUNCTION public.getdiscountid(birthdate date) OWNER TO postgres;

--
-- TOC entry 232 (class 1255 OID 42014)
-- Name: salaryChangesTR(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."salaryChangesTR"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF NEW."salary" <> OLD."salary" THEN
        INSERT INTO "SalaryChanges"("driverID", "oldSalary", "newSalary", "updatedOn")
        VALUES(OLD."driverID", OLD."salary", NEW."salary", CURRENT_TIMESTAMP::TIMESTAMP);
    END IF;

    RETURN NEW;
END;
$$;


ALTER FUNCTION public."salaryChangesTR"() OWNER TO postgres;

--
-- TOC entry 235 (class 1255 OID 49947)
-- Name: searchdistricts(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.searchdistricts(district integer) RETURNS TABLE("districtID" integer, "Name" character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT "districtNo", "name" FROM "District"
                 WHERE "districtNo" = district;
END;
$$;


ALTER FUNCTION public.searchdistricts(district integer) OWNER TO postgres;

--
-- TOC entry 234 (class 1255 OID 42065)
-- Name: setStatus(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."setStatus"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE "Driver"
	SET "status" = 'Busy'
    WHERE "Driver"."driverID" = NEW."driver";
	
	UPDATE "Bus"
	SET "status" = 'Busy'
    WHERE "Bus"."plateNo" = NEW."bus";

	RETURN NEW;
END;
$$;


ALTER FUNCTION public."setStatus"() OWNER TO postgres;

--
-- TOC entry 251 (class 1255 OID 50021)
-- Name: updateTrip(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."updateTrip"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE "Trip"
	SET "status" = 'Booked'
    WHERE "Trip"."tripID" = NEW."tripID";
           RETURN NEW;
	
END;
$$;


ALTER FUNCTION public."updateTrip"() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 203 (class 1259 OID 41431)
-- Name: Bus; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Bus" (
    "plateNo" integer NOT NULL,
    "brandName" character varying(40) NOT NULL,
    model character varying(40) NOT NULL,
    "numberOfSeats" smallint DEFAULT 20,
    status character varying(10) DEFAULT 'Available'::character varying,
    company integer DEFAULT 1
);


ALTER TABLE public."Bus" OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 41429)
-- Name: Bus_plateNo_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Bus_plateNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Bus_plateNo_seq" OWNER TO postgres;

--
-- TOC entry 3203 (class 0 OID 0)
-- Dependencies: 202
-- Name: Bus_plateNo_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Bus_plateNo_seq" OWNED BY public."Bus"."plateNo";


--
-- TOC entry 209 (class 1259 OID 41516)
-- Name: City; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."City" (
    "cityID" integer NOT NULL,
    name character varying(20) NOT NULL,
    "districtNo" integer NOT NULL
);


ALTER TABLE public."City" OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 41514)
-- Name: City_cityID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."City_cityID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."City_cityID_seq" OWNER TO postgres;

--
-- TOC entry 3204 (class 0 OID 0)
-- Dependencies: 208
-- Name: City_cityID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."City_cityID_seq" OWNED BY public."City"."cityID";


--
-- TOC entry 201 (class 1259 OID 41416)
-- Name: Company; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Company" (
    "companyID" integer NOT NULL,
    name character varying(40) NOT NULL,
    "districtNo" integer NOT NULL
);


ALTER TABLE public."Company" OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 41414)
-- Name: Company_companyID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Company_companyID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Company_companyID_seq" OWNER TO postgres;

--
-- TOC entry 3205 (class 0 OID 0)
-- Dependencies: 200
-- Name: Company_companyID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Company_companyID_seq" OWNED BY public."Company"."companyID";


--
-- TOC entry 211 (class 1259 OID 41542)
-- Name: ContactInformation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ContactInformation" (
    "contactID" integer NOT NULL,
    "phoneNo" character varying(20) NOT NULL,
    email character varying(30),
    "districtNo" integer,
    company integer
);


ALTER TABLE public."ContactInformation" OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 41540)
-- Name: ContactInformation_contactID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ContactInformation_contactID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."ContactInformation_contactID_seq" OWNER TO postgres;

--
-- TOC entry 3206 (class 0 OID 0)
-- Dependencies: 210
-- Name: ContactInformation_contactID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ContactInformation_contactID_seq" OWNED BY public."ContactInformation"."contactID";


--
-- TOC entry 229 (class 1259 OID 41725)
-- Name: Discount; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Discount" (
    "discountID" integer NOT NULL,
    name character varying(30) NOT NULL,
    "discountRate" real NOT NULL
);


ALTER TABLE public."Discount" OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 41723)
-- Name: Discount_discountID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Discount_discountID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Discount_discountID_seq" OWNER TO postgres;

--
-- TOC entry 3207 (class 0 OID 0)
-- Dependencies: 228
-- Name: Discount_discountID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Discount_discountID_seq" OWNED BY public."Discount"."discountID";


--
-- TOC entry 207 (class 1259 OID 41480)
-- Name: District; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."District" (
    "districtNo" integer NOT NULL,
    name character varying(20) NOT NULL
);


ALTER TABLE public."District" OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 41478)
-- Name: District_districtNo_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."District_districtNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."District_districtNo_seq" OWNER TO postgres;

--
-- TOC entry 3208 (class 0 OID 0)
-- Dependencies: 206
-- Name: District_districtNo_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."District_districtNo_seq" OWNED BY public."District"."districtNo";


--
-- TOC entry 213 (class 1259 OID 41562)
-- Name: Driver; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Driver" (
    "driverID" integer NOT NULL,
    name character varying(30) NOT NULL,
    surname character varying(30) NOT NULL,
    salary integer NOT NULL,
    status character varying(10) DEFAULT 'Available'::character varying,
    "plateNo" integer NOT NULL,
    contact integer,
    company integer NOT NULL
);


ALTER TABLE public."Driver" OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 41560)
-- Name: Driver_driverID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Driver_driverID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Driver_driverID_seq" OWNER TO postgres;

--
-- TOC entry 3209 (class 0 OID 0)
-- Dependencies: 212
-- Name: Driver_driverID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Driver_driverID_seq" OWNED BY public."Driver"."driverID";


--
-- TOC entry 215 (class 1259 OID 41597)
-- Name: Passenger; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Passenger" (
    "passengerID" integer NOT NULL,
    name character varying(30) NOT NULL,
    surname character varying(30) NOT NULL,
    "birthDate" date NOT NULL,
    contact integer NOT NULL,
    "userID" integer
);


ALTER TABLE public."Passenger" OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 41595)
-- Name: Passenger_passengerID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Passenger_passengerID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Passenger_passengerID_seq" OWNER TO postgres;

--
-- TOC entry 3210 (class 0 OID 0)
-- Dependencies: 214
-- Name: Passenger_passengerID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Passenger_passengerID_seq" OWNED BY public."Passenger"."passengerID";


--
-- TOC entry 217 (class 1259 OID 41617)
-- Name: Payment; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Payment" (
    "paymentID" integer NOT NULL,
    amount character varying(30) NOT NULL,
    passenger integer NOT NULL,
    reservation integer NOT NULL
);


ALTER TABLE public."Payment" OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 41615)
-- Name: Payment_paymentID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Payment_paymentID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Payment_paymentID_seq" OWNER TO postgres;

--
-- TOC entry 3211 (class 0 OID 0)
-- Dependencies: 216
-- Name: Payment_paymentID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Payment_paymentID_seq" OWNED BY public."Payment"."paymentID";


--
-- TOC entry 225 (class 1259 OID 41684)
-- Name: Reservation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Reservation" (
    "reservationID" integer NOT NULL,
    "journeyDate" date NOT NULL,
    "seatNo" smallint NOT NULL,
    "passengerID" integer NOT NULL,
    "tripID" integer NOT NULL,
    "ticketID" integer NOT NULL,
    discount integer
);


ALTER TABLE public."Reservation" OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 41682)
-- Name: Reservation_reservationID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Reservation_reservationID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Reservation_reservationID_seq" OWNER TO postgres;

--
-- TOC entry 3212 (class 0 OID 0)
-- Dependencies: 224
-- Name: Reservation_reservationID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Reservation_reservationID_seq" OWNED BY public."Reservation"."reservationID";


--
-- TOC entry 221 (class 1259 OID 41658)
-- Name: Route; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Route" (
    "routeID" integer NOT NULL,
    departure character varying(30) NOT NULL,
    destination character varying(30) NOT NULL,
    distance character varying(20),
    station integer
);


ALTER TABLE public."Route" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 41656)
-- Name: Route_routeID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Route_routeID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Route_routeID_seq" OWNER TO postgres;

--
-- TOC entry 3213 (class 0 OID 0)
-- Dependencies: 220
-- Name: Route_routeID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Route_routeID_seq" OWNED BY public."Route"."routeID";


--
-- TOC entry 231 (class 1259 OID 42006)
-- Name: SalaryChanges; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."SalaryChanges" (
    "recordNo" integer NOT NULL,
    "driverID" smallint NOT NULL,
    "oldSalary" real NOT NULL,
    "newSalary" real NOT NULL,
    "updatedOn" timestamp without time zone NOT NULL
);


ALTER TABLE public."SalaryChanges" OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 42004)
-- Name: SalaryChanges_recordNo_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."SalaryChanges_recordNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."SalaryChanges_recordNo_seq" OWNER TO postgres;

--
-- TOC entry 3214 (class 0 OID 0)
-- Dependencies: 230
-- Name: SalaryChanges_recordNo_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."SalaryChanges_recordNo_seq" OWNED BY public."SalaryChanges"."recordNo";


--
-- TOC entry 223 (class 1259 OID 41671)
-- Name: Station; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Station" (
    "stationID" integer NOT NULL,
    name character varying(30) NOT NULL,
    location character varying(30) NOT NULL
);


ALTER TABLE public."Station" OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 41669)
-- Name: Station_stationID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Station_stationID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Station_stationID_seq" OWNER TO postgres;

--
-- TOC entry 3215 (class 0 OID 0)
-- Dependencies: 222
-- Name: Station_stationID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Station_stationID_seq" OWNED BY public."Station"."stationID";


--
-- TOC entry 227 (class 1259 OID 41707)
-- Name: Ticket; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Ticket" (
    "ticketID" integer NOT NULL,
    price money NOT NULL,
    trip integer
);


ALTER TABLE public."Ticket" OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 41705)
-- Name: Ticket_ticketID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Ticket_ticketID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Ticket_ticketID_seq" OWNER TO postgres;

--
-- TOC entry 3216 (class 0 OID 0)
-- Dependencies: 226
-- Name: Ticket_ticketID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Ticket_ticketID_seq" OWNED BY public."Ticket"."ticketID";


--
-- TOC entry 219 (class 1259 OID 41639)
-- Name: Trip; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Trip" (
    "tripID" integer NOT NULL,
    "departureTime" time without time zone NOT NULL,
    "arrivalTime" time without time zone NOT NULL,
    "travelDuration" character varying(30),
    status character varying(10) DEFAULT 'Unbooked'::character varying,
    bus integer NOT NULL,
    driver integer NOT NULL,
    route integer NOT NULL
);


ALTER TABLE public."Trip" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 41637)
-- Name: Trip_tripID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Trip_tripID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Trip_tripID_seq" OWNER TO postgres;

--
-- TOC entry 3217 (class 0 OID 0)
-- Dependencies: 218
-- Name: Trip_tripID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Trip_tripID_seq" OWNED BY public."Trip"."tripID";


--
-- TOC entry 205 (class 1259 OID 41463)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "userID" integer NOT NULL,
    username character varying(20) NOT NULL,
    password character varying(10) NOT NULL,
    email character varying(30) NOT NULL,
    type character(1) DEFAULT 'P'::bpchar,
    status character varying(10) DEFAULT 'Passive'::character varying
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 41461)
-- Name: Users_userID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Users_userID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Users_userID_seq" OWNER TO postgres;

--
-- TOC entry 3218 (class 0 OID 0)
-- Dependencies: 204
-- Name: Users_userID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Users_userID_seq" OWNED BY public."Users"."userID";


--
-- TOC entry 2951 (class 2604 OID 41434)
-- Name: Bus plateNo; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Bus" ALTER COLUMN "plateNo" SET DEFAULT nextval('public."Bus_plateNo_seq"'::regclass);


--
-- TOC entry 2959 (class 2604 OID 41519)
-- Name: City cityID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."City" ALTER COLUMN "cityID" SET DEFAULT nextval('public."City_cityID_seq"'::regclass);


--
-- TOC entry 2950 (class 2604 OID 41419)
-- Name: Company companyID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Company" ALTER COLUMN "companyID" SET DEFAULT nextval('public."Company_companyID_seq"'::regclass);


--
-- TOC entry 2960 (class 2604 OID 41545)
-- Name: ContactInformation contactID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactInformation" ALTER COLUMN "contactID" SET DEFAULT nextval('public."ContactInformation_contactID_seq"'::regclass);


--
-- TOC entry 2971 (class 2604 OID 41728)
-- Name: Discount discountID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Discount" ALTER COLUMN "discountID" SET DEFAULT nextval('public."Discount_discountID_seq"'::regclass);


--
-- TOC entry 2958 (class 2604 OID 41483)
-- Name: District districtNo; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."District" ALTER COLUMN "districtNo" SET DEFAULT nextval('public."District_districtNo_seq"'::regclass);


--
-- TOC entry 2961 (class 2604 OID 41565)
-- Name: Driver driverID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Driver" ALTER COLUMN "driverID" SET DEFAULT nextval('public."Driver_driverID_seq"'::regclass);


--
-- TOC entry 2963 (class 2604 OID 41600)
-- Name: Passenger passengerID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Passenger" ALTER COLUMN "passengerID" SET DEFAULT nextval('public."Passenger_passengerID_seq"'::regclass);


--
-- TOC entry 2964 (class 2604 OID 41620)
-- Name: Payment paymentID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Payment" ALTER COLUMN "paymentID" SET DEFAULT nextval('public."Payment_paymentID_seq"'::regclass);


--
-- TOC entry 2969 (class 2604 OID 41687)
-- Name: Reservation reservationID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reservation" ALTER COLUMN "reservationID" SET DEFAULT nextval('public."Reservation_reservationID_seq"'::regclass);


--
-- TOC entry 2967 (class 2604 OID 41661)
-- Name: Route routeID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Route" ALTER COLUMN "routeID" SET DEFAULT nextval('public."Route_routeID_seq"'::regclass);


--
-- TOC entry 2972 (class 2604 OID 42009)
-- Name: SalaryChanges recordNo; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SalaryChanges" ALTER COLUMN "recordNo" SET DEFAULT nextval('public."SalaryChanges_recordNo_seq"'::regclass);


--
-- TOC entry 2968 (class 2604 OID 41674)
-- Name: Station stationID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Station" ALTER COLUMN "stationID" SET DEFAULT nextval('public."Station_stationID_seq"'::regclass);


--
-- TOC entry 2970 (class 2604 OID 41710)
-- Name: Ticket ticketID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ticket" ALTER COLUMN "ticketID" SET DEFAULT nextval('public."Ticket_ticketID_seq"'::regclass);


--
-- TOC entry 2965 (class 2604 OID 41642)
-- Name: Trip tripID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Trip" ALTER COLUMN "tripID" SET DEFAULT nextval('public."Trip_tripID_seq"'::regclass);


--
-- TOC entry 2955 (class 2604 OID 41466)
-- Name: Users userID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users" ALTER COLUMN "userID" SET DEFAULT nextval('public."Users_userID_seq"'::regclass);


--
-- TOC entry 3168 (class 0 OID 41431)
-- Dependencies: 203
-- Data for Name: Bus; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (1111, '2134', '4124', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (12, '134', '124', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (124241124, '12', '12', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (333333, 'Eurotracker', 'ER345', 14, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (895623, 'Isuzu', 'IS3234', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (21, '214', 'rrr241', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (24, 'dddd', '123', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (784512, 'Toyota', 'TER234', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (12444, '124', '123412', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (7812184, 'Volvo', 'VR2314', 20, 'Available', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (784125, 'Scania', 'DA3ERMAX-32', 20, 'Available', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (451866, 'DAF', 'DAF-TUF-32MAXI', 20, 'Available', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (4515699, 'Isuzu', '78IS-2021', 18, 'Available', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (456789, 'Mercedes', 'MW49', 18, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (789456, 'Volks Wagen', 'VW34', 16, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (2312111, 'eewew', 'qqq', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (444, '234', '2352', 20, 'Busy', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (123456, 'Volvo', 'V3ER', 20, 'Available', 1);
INSERT INTO public."Bus" ("plateNo", "brandName", model, "numberOfSeats", status, company) VALUES (789789, 'test', 'ER32', 10, 'Available', 1);


--
-- TOC entry 3174 (class 0 OID 41516)
-- Dependencies: 209
-- Data for Name: City; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (1, 'Sakarya', 1);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (2, 'Sakarya', 7);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (3, 'Sakarya', 8);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (4, 'Sakarya', 9);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (5, 'Istanbul', 2);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (6, 'Istanbul', 3);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (7, 'Bursa', 10);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (8, 'Bursa', 11);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (9, 'Istanbul', 4);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (10, 'Bursa', 12);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (11, 'Istanbul', 5);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (12, 'Bursa', 13);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (13, 'Istanbul', 6);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (14, 'Izmir', 17);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (15, 'Izmir', 16);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (16, 'Ankara', 20);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (17, 'Ankara', 19);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (18, 'Izmir', 14);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (19, 'Ankara', 18);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (21, 'Izmir', 15);
INSERT INTO public."City" ("cityID", name, "districtNo") VALUES (22, 'Ankara', 21);


--
-- TOC entry 3166 (class 0 OID 41416)
-- Dependencies: 201
-- Data for Name: Company; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Company" ("companyID", name, "districtNo") VALUES (1, 'Epix Travel Ltd', 1);


--
-- TOC entry 3176 (class 0 OID 41542)
-- Dependencies: 211
-- Data for Name: ContactInformation; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (1, '5539501268', 'testting@epix.com', 1, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (9, '8494916986', 'driver@epixtravels.com', 1, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (10, '475788878', NULL, 1, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (11, '1241312413', 'wow@epixtravels.com', 1, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (12, '05547894512', 'New@epixtravels.com', 2, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (13, '055784512', 'Testing@epixtravels.com', 4, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (16, '05578451212', 'Testinga@epixtravels.com', 4, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (17, '4556422246', 'sofor@epixtravels.com', 20, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (18, '111111111', 'Check@epixtravels.com', 11, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (19, '222222222222222', 'Checking@epixtravels.com', 17, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (29, '054687121584', 'NewPassenger@gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (30, '05784512281', 'Izmir@gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (31, '78577852778', 'dw@hotmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (32, '78513848', 'cool@yahoo.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (33, '12412', 're@gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (34, '984518', 'fe@gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (35, '1241241', 'check@hotmalci.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (36, '12413412', 'jamy@gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (37, '214241341', 'ozil@gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (38, '1241242', 'resul@gmaul.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (39, '21412', 'deejoong@gamil.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (41, '214141231423', 'Jota@gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (42, '12421412412', 'alonso@gamilk..com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (43, '054813198435', 'Elon@genius.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (44, '0654238329', 'burak@gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (45, '0548213218', 'Umer@epixtravels.com', 17, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (46, '06518158165', 'Mohammed@epixtravels.com', 19, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (47, '05168428', 'fanos@gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (48, '051584235', 'Bedru@epixtravels.com', 7, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (49, '05379743876', 'percy4669gmail.com@ ', NULL, NULL);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (50, '0581321584', 'Raul@epixtravels.com', 4, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (51, '0521219812', 'Joa@epixtravels.com', 18, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (52, '0518415825', 'Diego@epixtravels.com', 14, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (53, '0545125413', 'Aydin@epixtravels.com', 20, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (54, '0511823532', 'Wasiq@epixtravels.com', 1, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (55, '0548412545', 'Mehmet@epixtravels.com', 11, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (56, '0548722185', 'Murat@epixtravels.com', 3, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (57, '0548251836', 'Alexander@epixtravels.com', 11, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (58, '0541384123', 'Andy@epixtravels.com', 5, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (59, '0541234811', 'Mert@epixtravels.com', 4, 1);
INSERT INTO public."ContactInformation" ("contactID", "phoneNo", email, "districtNo", company) VALUES (60, '054217843', 'Ibrahim@epixtravels.com', 8, 1);


--
-- TOC entry 3194 (class 0 OID 41725)
-- Dependencies: 229
-- Data for Name: Discount; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Discount" ("discountID", name, "discountRate") VALUES (2, 'Above 60', 0.2);
INSERT INTO public."Discount" ("discountID", name, "discountRate") VALUES (5, 'Normal', 0);
INSERT INTO public."Discount" ("discountID", name, "discountRate") VALUES (1, 'Student Under 24', 0.3);


--
-- TOC entry 3172 (class 0 OID 41480)
-- Dependencies: 207
-- Data for Name: District; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."District" ("districtNo", name) VALUES (1, 'Serdivan');
INSERT INTO public."District" ("districtNo", name) VALUES (2, 'Üsküdar');
INSERT INTO public."District" ("districtNo", name) VALUES (3, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (4, 'Fatih');
INSERT INTO public."District" ("districtNo", name) VALUES (5, 'Beşiktaş');
INSERT INTO public."District" ("districtNo", name) VALUES (6, 'Pendik');
INSERT INTO public."District" ("districtNo", name) VALUES (7, 'Arifiye');
INSERT INTO public."District" ("districtNo", name) VALUES (8, 'Adapazarı');
INSERT INTO public."District" ("districtNo", name) VALUES (9, 'Erenler');
INSERT INTO public."District" ("districtNo", name) VALUES (10, 'Osmangazi');
INSERT INTO public."District" ("districtNo", name) VALUES (11, 'Gürsu');
INSERT INTO public."District" ("districtNo", name) VALUES (12, 'Orhaneli ');
INSERT INTO public."District" ("districtNo", name) VALUES (13, 'Karacabey');
INSERT INTO public."District" ("districtNo", name) VALUES (14, 'Bayraklı');
INSERT INTO public."District" ("districtNo", name) VALUES (15, 'Güzelbahçe');
INSERT INTO public."District" ("districtNo", name) VALUES (16, 'Bornova ');
INSERT INTO public."District" ("districtNo", name) VALUES (17, 'Gaziemir');
INSERT INTO public."District" ("districtNo", name) VALUES (18, 'Çankaya');
INSERT INTO public."District" ("districtNo", name) VALUES (19, 'Beypazarı');
INSERT INTO public."District" ("districtNo", name) VALUES (20, 'Kahramankazan ');
INSERT INTO public."District" ("districtNo", name) VALUES (21, 'Kalecik');
INSERT INTO public."District" ("districtNo", name) VALUES (22, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (23, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (24, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (25, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (26, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (27, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (28, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (29, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (30, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (31, 'Üsküdar');
INSERT INTO public."District" ("districtNo", name) VALUES (32, 'Fatih');
INSERT INTO public."District" ("districtNo", name) VALUES (33, 'Fatih');
INSERT INTO public."District" ("districtNo", name) VALUES (34, 'Fatih');
INSERT INTO public."District" ("districtNo", name) VALUES (35, 'Fatih');
INSERT INTO public."District" ("districtNo", name) VALUES (36, 'Kahramankazan ');
INSERT INTO public."District" ("districtNo", name) VALUES (37, 'Gürsu');
INSERT INTO public."District" ("districtNo", name) VALUES (38, 'Gürsu');
INSERT INTO public."District" ("districtNo", name) VALUES (39, 'Gaziemir');
INSERT INTO public."District" ("districtNo", name) VALUES (40, 'Gaziemir');
INSERT INTO public."District" ("districtNo", name) VALUES (41, 'Gaziemir');
INSERT INTO public."District" ("districtNo", name) VALUES (42, 'Gaziemir');
INSERT INTO public."District" ("districtNo", name) VALUES (43, 'Gaziemir');
INSERT INTO public."District" ("districtNo", name) VALUES (44, 'Beypazarı');
INSERT INTO public."District" ("districtNo", name) VALUES (45, 'Arifiye');
INSERT INTO public."District" ("districtNo", name) VALUES (46, 'Arifiye');
INSERT INTO public."District" ("districtNo", name) VALUES (47, 'Fatih');
INSERT INTO public."District" ("districtNo", name) VALUES (48, 'Çankaya');
INSERT INTO public."District" ("districtNo", name) VALUES (49, 'Bayraklı');
INSERT INTO public."District" ("districtNo", name) VALUES (50, 'Kahramankazan ');
INSERT INTO public."District" ("districtNo", name) VALUES (51, 'Serdivan');
INSERT INTO public."District" ("districtNo", name) VALUES (52, 'Gürsu');
INSERT INTO public."District" ("districtNo", name) VALUES (53, 'Kadiköy');
INSERT INTO public."District" ("districtNo", name) VALUES (54, 'Gürsu');
INSERT INTO public."District" ("districtNo", name) VALUES (55, 'Beşiktaş');
INSERT INTO public."District" ("districtNo", name) VALUES (56, 'Fatih');
INSERT INTO public."District" ("districtNo", name) VALUES (57, 'Adapazarı');


--
-- TOC entry 3178 (class 0 OID 41562)
-- Dependencies: 213
-- Data for Name: Driver; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (23, 'Wasiq', 'MASOOD', 5000, 'Busy', 456789, 54, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (24, 'Mehmet', 'OĞUZ', 4500, 'Busy', 789456, 55, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (25, 'Murat', 'YıLMAZ', 4700, 'Busy', 2312111, 56, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (27, 'Andy', 'ROBERTSON', 4900, 'Available', 784125, 58, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (28, 'Mert', 'YıLMAZ', 5500, 'Available', 4515699, 59, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (29, 'Ibrahim', 'YAPMAZ', 6500, 'Available', 7812184, 60, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (26, 'Alexander', 'ARNOLD', 7800, 'Busy', 444, 57, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (3, 'SMALLLETTERS', 'SMALLLETTERS', 5000, 'Available', 123456, 1, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (15, 'Umer', 'FATIH', 6500, 'Busy', 895623, 45, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (18, 'Bedru', 'UMER', 5400, 'Busy', 24, 48, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (22, 'Aydin', 'GÖZ', 4500, 'Busy', 789456, 53, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (5, 'triggertest', 'SMALLLETTERS', 5000, 'Busy', 123456, 1, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (10, 'Check', 'AGAIN', 6000, 'Busy', 1111, NULL, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (12, 'Checking', 'AGAAAIN', 4500, 'Busy', 12, 19, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (13, 'Checking', 'AGAAAIN', 4500, 'Busy', 12, NULL, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (8, 'sofor', 'YENI', 5000, 'Busy', 124241124, 17, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (7, 'Testinga', 'NEW', 5222, 'Busy', 333333, 16, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (16, 'Mohammed', 'BEYLUL', 5000, 'Busy', 21, 46, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (4, 'SMALLLETTERS', 'SMALLLETTERS', 4000, 'Busy', 123456, 1, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (19, 'Raul', 'GONZALEZ', 4500, 'Busy', 784512, 50, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (20, 'Joa', 'CANCELO', 6000, 'Busy', 12444, 51, 1);
INSERT INTO public."Driver" ("driverID", name, surname, salary, status, "plateNo", contact, company) VALUES (21, 'Diego', 'JOTA', 4500, 'Busy', 12444, 52, 1);


--
-- TOC entry 3180 (class 0 OID 41597)
-- Dependencies: 215
-- Data for Name: Passenger; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (5, 'New', 'Passenger', '2000-03-16', 29, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (6, 'Izmire', 'Gidiyorum', '1960-12-31', 30, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (7, 'hi', 'hi', '2000-07-04', 31, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (8, 'young', 'Boy', '2000-07-12', 32, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (9, 'hi', 'juyf', '1990-12-31', 33, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (10, 'Henry', 'Theo', '1960-12-31', 34, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (11, 'theo', 'walcott', '2001-06-01', 35, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (12, 'jamy', 'vardy', '1960-12-31', 36, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (13, 'mesut', 'ozil', '1940-12-31', 37, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (14, 'resul', 'daspinar', '2000-07-04', 38, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (15, 'Frank', 'de Jong', '1990-01-31', 39, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (17, 'Joa', 'Jota', '1991-12-31', 41, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (18, 'alonso', 'dee', '2000-12-31', 42, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (19, 'Elon', 'Musk', '1975-03-12', 43, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (20, 'Burak', 'Koca', '2000-07-12', 44, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (21, 'fanos', 'adem', '2000-12-31', 47, 1);
INSERT INTO public."Passenger" ("passengerID", name, surname, "birthDate", contact, "userID") VALUES (22, 'Mert', 'Akpınar', '1999-02-03', 49, 1);


--
-- TOC entry 3182 (class 0 OID 41617)
-- Dependencies: 217
-- Data for Name: Payment; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (6, '175', 6, 6);
INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (7, '175', 7, 7);
INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (8, '175', 8, 8);
INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (11, '280', 11, 11);
INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (17, '250', 17, 17);
INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (18, '175', 18, 18);
INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (19, '90', 19, 19);
INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (20, '175', 20, 20);
INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (21, '140', 21, 21);
INSERT INTO public."Payment" ("paymentID", amount, passenger, reservation) VALUES (22, '49', 22, 22);


--
-- TOC entry 3190 (class 0 OID 41684)
-- Dependencies: 225
-- Data for Name: Reservation; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (6, '2021-12-30', 4, 6, 44, 10, 1);
INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (7, '2021-12-18', 0, 7, 43, 9, 1);
INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (8, '2021-12-13', 0, 8, 44, 10, 1);
INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (11, '2021-12-13', 7, 11, 41, 7, 1);
INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (17, '2021-12-13', 1, 17, 44, 10, 5);
INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (18, '2021-12-13', 5, 18, 44, 10, 1);
INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (19, '2021-12-13', 0, 19, 46, 12, 5);
INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (20, '2021-12-13', 8, 20, 44, 10, 1);
INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (21, '2021-12-14', 2, 21, 43, 9, 1);
INSERT INTO public."Reservation" ("reservationID", "journeyDate", "seatNo", "passengerID", "tripID", "ticketID", discount) VALUES (22, '2021-12-16', 5, 22, 51, 17, 1);


--
-- TOC entry 3186 (class 0 OID 41658)
-- Dependencies: 221
-- Data for Name: Route; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (6, 'Ankara', 'Istanbul', '380', 17);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (7, 'Bursa', 'Istanbul', '250Km', 17);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (8, 'Bursa', 'Izmir', '350Km', 21);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (9, 'Sakarya', 'Izmir', '340Km', 21);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (10, 'Sakarya', 'Istanbul', '120Km', 17);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (11, 'Ankara', 'Sakarya', '450Km', 22);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (12, 'Ankara', 'Izmir', '450Km', 21);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (13, 'Izmir', 'Istanbul', '450Km', 17);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (14, 'Sakarya', 'Ankara', '340Km', 16);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (15, 'Bursa', 'Sakarya', '400Km', 22);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (16, 'Izmir', 'Sakarya', '120Km', 22);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (17, 'Sakarya', 'Izmir', '499Km', 21);
INSERT INTO public."Route" ("routeID", departure, destination, distance, station) VALUES (18, 'Bursa', 'Ankara', '450Km', 16);


--
-- TOC entry 3196 (class 0 OID 42006)
-- Dependencies: 231
-- Data for Name: SalaryChanges; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (1, 4, 3000, 4000, '2021-12-09 17:24:23.13356');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (2, 8, 7800, 6000, '2021-12-10 18:50:33.531276');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (3, 5, 3000, 5000, '2021-12-10 18:52:25.737664');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (4, 8, 6000, 5000, '2021-12-10 19:02:48.920452');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (5, 7, 3500, 5222, '2021-12-10 20:20:47.700011');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (6, 3, 3000, 2500, '2021-12-11 13:27:09.41792');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (7, 3, 2500, 3000, '2021-12-16 10:26:15.747942');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (8, 22, 3500, 4000, '2021-12-16 11:38:51.771254');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (9, 3, 3000, 5000, '2021-12-16 16:46:18.893843');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (10, 15, 3200, 6500, '2021-12-16 16:46:34.651985');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (11, 18, 3000, 5400, '2021-12-16 16:46:48.789818');
INSERT INTO public."SalaryChanges" ("recordNo", "driverID", "oldSalary", "newSalary", "updatedOn") VALUES (12, 22, 4000, 4500, '2021-12-16 16:46:53.538096');


--
-- TOC entry 3188 (class 0 OID 41671)
-- Dependencies: 223
-- Data for Name: Station; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Station" ("stationID", name, location) VALUES (16, 'Ankara Terminal', 'Ankara');
INSERT INTO public."Station" ("stationID", name, location) VALUES (17, 'Harem', 'Istanbul');
INSERT INTO public."Station" ("stationID", name, location) VALUES (18, 'Bursa Terminal`', 'Bursa');
INSERT INTO public."Station" ("stationID", name, location) VALUES (19, 'Esenler', 'Istanbul');
INSERT INTO public."Station" ("stationID", name, location) VALUES (20, 'Bursa Terminal`', 'Bursa');
INSERT INTO public."Station" ("stationID", name, location) VALUES (21, 'Izmir Terminal', 'Izmir');
INSERT INTO public."Station" ("stationID", name, location) VALUES (22, 'Sakarya Terminal', 'Sakarya');
INSERT INTO public."Station" ("stationID", name, location) VALUES (23, 'Izmir Terminal', 'Izmir');
INSERT INTO public."Station" ("stationID", name, location) VALUES (24, 'Sakarya Terminal', 'Sakarya');
INSERT INTO public."Station" ("stationID", name, location) VALUES (25, 'Esenler', 'Istanbul');
INSERT INTO public."Station" ("stationID", name, location) VALUES (26, 'Ankara Terminal', 'Ankara');
INSERT INTO public."Station" ("stationID", name, location) VALUES (27, 'Sakarya Terminal', 'Sakarya');
INSERT INTO public."Station" ("stationID", name, location) VALUES (28, 'Ankara Terminal', 'Ankara');
INSERT INTO public."Station" ("stationID", name, location) VALUES (29, 'Izmir Terminal', 'Izmir');
INSERT INTO public."Station" ("stationID", name, location) VALUES (30, 'Izmir Terminal', 'Izmir');
INSERT INTO public."Station" ("stationID", name, location) VALUES (31, 'Harem', 'Istanbul');
INSERT INTO public."Station" ("stationID", name, location) VALUES (32, 'sakarya Terminal', 'Sakarya');
INSERT INTO public."Station" ("stationID", name, location) VALUES (33, 'Ankara Terminal', 'Ankara');
INSERT INTO public."Station" ("stationID", name, location) VALUES (34, 'Bursa Terminal', 'Bursa');
INSERT INTO public."Station" ("stationID", name, location) VALUES (35, 'Sakarya Terminal', 'Sakarya');
INSERT INTO public."Station" ("stationID", name, location) VALUES (36, 'izmir', 'Izmir');
INSERT INTO public."Station" ("stationID", name, location) VALUES (37, 'sakarya', 'Sakarya');
INSERT INTO public."Station" ("stationID", name, location) VALUES (38, 'Sakarya Terminal', 'Sakarya');
INSERT INTO public."Station" ("stationID", name, location) VALUES (39, 'Izmir Terminal', 'Izmir');
INSERT INTO public."Station" ("stationID", name, location) VALUES (40, 'Bursa Terminal', 'Bursa');
INSERT INTO public."Station" ("stationID", name, location) VALUES (41, 'Ankara Terminal', 'Ankara');


--
-- TOC entry 3192 (class 0 OID 41707)
-- Dependencies: 227
-- Data for Name: Ticket; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (1, '$75.00', NULL);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (3, '$55.00', NULL);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (4, '$120.00', NULL);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (5, '$120.00', NULL);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (6, '$450.00', NULL);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (12, '$90.00', 46);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (14, '$80.00', 48);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (15, '$90.00', 49);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (16, '$90.00', 47);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (17, '$70.00', 51);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (18, '$75.00', 52);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (19, '$60.00', 53);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (20, '$60.00', 54);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (9, '$80.00', 43);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (10, '$89.00', 44);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (21, '$95.00', 55);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (22, '$89.00', 56);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (23, '$89.00', 57);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (24, '$89.00', 58);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (2, '$95.00', NULL);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (7, '$55.00', 41);
INSERT INTO public."Ticket" ("ticketID", price, trip) VALUES (25, '$150.00', 59);


--
-- TOC entry 3184 (class 0 OID 41639)
-- Dependencies: 219
-- Data for Name: Trip; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (40, '02:54:00', '04:00:00', '01:06:00', 'Unbooked', 1111, 10, 9);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (41, '03:00:00', '05:00:00', '02:00:00', 'Unbooked', 12, 12, 10);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (46, '09:00:00', '12:30:00', '03:30:00', 'Booked', 333333, 7, 13);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (44, '09:06:00', '11:00:00', '01:54:00', 'Booked', 124241124, 8, 8);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (47, '08:30:00', '12:00:00', '03:30:00', 'Unbooked', 123456, 4, 15);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (48, '10:55:00', '10:55:00', '00:00:00', 'Unbooked', 895623, 15, 15);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (49, '10:55:00', '10:55:00', '00:00:00', 'Unbooked', 21, 16, 15);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (50, '07:02:00', '09:02:00', '02:00:00', 'Unbooked', 123456, 4, 16);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (43, '07:00:00', '09:00:00', '02:00:00', 'Booked', 12, 13, 10);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (51, '09:00:00', '12:30:00', '03:30:00', 'Booked', 24, 18, 9);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (52, '10:45:00', '12:15:00', '01:30:00', 'Unbooked', 784512, 19, 10);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (53, '06:30:00', '08:00:00', '01:30:00', 'Unbooked', 12444, 20, 10);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (54, '08:30:00', '10:15:00', '01:45:00', 'Unbooked', 12444, 21, 10);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (55, '10:30:00', '12:45:00', '02:15:00', 'Unbooked', 789456, 22, 8);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (57, '07:30:00', '09:45:00', '02:15:00', 'Unbooked', 789456, 24, 8);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (58, '05:30:00', '08:45:00', '03:15:00', 'Unbooked', 2312111, 25, 8);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (56, '12:30:00', '02:45:00', '03:15:00', 'Unbooked', 456789, 23, 8);
INSERT INTO public."Trip" ("tripID", "departureTime", "arrivalTime", "travelDuration", status, bus, driver, route) VALUES (59, '07:15:00', '11:45:00', '04:30:00', 'Unbooked', 444, 26, 14);


--
-- TOC entry 3170 (class 0 OID 41463)
-- Dependencies: 205
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Users" ("userID", username, password, email, type, status) VALUES (2, 'admin', '456', 'admin@epix.com', 'A', 'Passive');
INSERT INTO public."Users" ("userID", username, password, email, type, status) VALUES (6, 'check', '1234', 'check@gmail.com', 'P', 'Passive');
INSERT INTO public."Users" ("userID", username, password, email, type, status) VALUES (7, 'deneme', '963', 'deneme@gmail.com', 'P', 'Passive');
INSERT INTO public."Users" ("userID", username, password, email, type, status) VALUES (1, 'bedru', '123', 'test@gmail.com', 'P', 'Passive');


--
-- TOC entry 3219 (class 0 OID 0)
-- Dependencies: 202
-- Name: Bus_plateNo_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Bus_plateNo_seq"', 1, false);


--
-- TOC entry 3220 (class 0 OID 0)
-- Dependencies: 208
-- Name: City_cityID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."City_cityID_seq"', 22, true);


--
-- TOC entry 3221 (class 0 OID 0)
-- Dependencies: 200
-- Name: Company_companyID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Company_companyID_seq"', 1, true);


--
-- TOC entry 3222 (class 0 OID 0)
-- Dependencies: 210
-- Name: ContactInformation_contactID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ContactInformation_contactID_seq"', 60, true);


--
-- TOC entry 3223 (class 0 OID 0)
-- Dependencies: 228
-- Name: Discount_discountID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Discount_discountID_seq"', 5, true);


--
-- TOC entry 3224 (class 0 OID 0)
-- Dependencies: 206
-- Name: District_districtNo_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."District_districtNo_seq"', 57, true);


--
-- TOC entry 3225 (class 0 OID 0)
-- Dependencies: 212
-- Name: Driver_driverID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Driver_driverID_seq"', 29, true);


--
-- TOC entry 3226 (class 0 OID 0)
-- Dependencies: 214
-- Name: Passenger_passengerID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Passenger_passengerID_seq"', 22, true);


--
-- TOC entry 3227 (class 0 OID 0)
-- Dependencies: 216
-- Name: Payment_paymentID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Payment_paymentID_seq"', 22, true);


--
-- TOC entry 3228 (class 0 OID 0)
-- Dependencies: 224
-- Name: Reservation_reservationID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Reservation_reservationID_seq"', 22, true);


--
-- TOC entry 3229 (class 0 OID 0)
-- Dependencies: 220
-- Name: Route_routeID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Route_routeID_seq"', 18, true);


--
-- TOC entry 3230 (class 0 OID 0)
-- Dependencies: 230
-- Name: SalaryChanges_recordNo_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."SalaryChanges_recordNo_seq"', 12, true);


--
-- TOC entry 3231 (class 0 OID 0)
-- Dependencies: 222
-- Name: Station_stationID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Station_stationID_seq"', 41, true);


--
-- TOC entry 3232 (class 0 OID 0)
-- Dependencies: 226
-- Name: Ticket_ticketID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Ticket_ticketID_seq"', 26, true);


--
-- TOC entry 3233 (class 0 OID 0)
-- Dependencies: 218
-- Name: Trip_tripID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Trip_tripID_seq"', 60, true);


--
-- TOC entry 3234 (class 0 OID 0)
-- Dependencies: 204
-- Name: Users_userID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_userID_seq"', 7, true);


--
-- TOC entry 2990 (class 2606 OID 41568)
-- Name: Driver DriverPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Driver"
    ADD CONSTRAINT "DriverPK" PRIMARY KEY ("driverID");


--
-- TOC entry 3008 (class 2606 OID 42011)
-- Name: SalaryChanges PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SalaryChanges"
    ADD CONSTRAINT "PK" PRIMARY KEY ("recordNo");


--
-- TOC entry 2976 (class 2606 OID 41438)
-- Name: Bus busPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Bus"
    ADD CONSTRAINT "busPK" PRIMARY KEY ("plateNo");


--
-- TOC entry 2982 (class 2606 OID 41521)
-- Name: City cityPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."City"
    ADD CONSTRAINT "cityPK" PRIMARY KEY ("cityID");


--
-- TOC entry 2974 (class 2606 OID 41421)
-- Name: Company companyPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Company"
    ADD CONSTRAINT "companyPK" PRIMARY KEY ("companyID");


--
-- TOC entry 2984 (class 2606 OID 41547)
-- Name: ContactInformation contactInformationPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactInformation"
    ADD CONSTRAINT "contactInformationPK" PRIMARY KEY ("contactID");


--
-- TOC entry 3006 (class 2606 OID 41730)
-- Name: Discount discountPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Discount"
    ADD CONSTRAINT "discountPK" PRIMARY KEY ("discountID");


--
-- TOC entry 2980 (class 2606 OID 41485)
-- Name: District districtPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."District"
    ADD CONSTRAINT "districtPK" PRIMARY KEY ("districtNo");


--
-- TOC entry 2992 (class 2606 OID 41602)
-- Name: Passenger passengerPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Passenger"
    ADD CONSTRAINT "passengerPK" PRIMARY KEY ("passengerID");


--
-- TOC entry 2994 (class 2606 OID 41622)
-- Name: Payment paymentPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Payment"
    ADD CONSTRAINT "paymentPK" PRIMARY KEY ("paymentID");


--
-- TOC entry 3002 (class 2606 OID 41689)
-- Name: Reservation reservationPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reservation"
    ADD CONSTRAINT "reservationPK" PRIMARY KEY ("reservationID");


--
-- TOC entry 2998 (class 2606 OID 41663)
-- Name: Route routePK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Route"
    ADD CONSTRAINT "routePK" PRIMARY KEY ("routeID");


--
-- TOC entry 3000 (class 2606 OID 41676)
-- Name: Station stationPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Station"
    ADD CONSTRAINT "stationPK" PRIMARY KEY ("stationID");


--
-- TOC entry 3004 (class 2606 OID 41712)
-- Name: Ticket ticketPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ticket"
    ADD CONSTRAINT "ticketPK" PRIMARY KEY ("ticketID");


--
-- TOC entry 2996 (class 2606 OID 41645)
-- Name: Trip tripPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Trip"
    ADD CONSTRAINT "tripPK" PRIMARY KEY ("tripID");


--
-- TOC entry 2978 (class 2606 OID 41469)
-- Name: Users userPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "userPK" PRIMARY KEY ("userID");


--
-- TOC entry 2986 (class 2606 OID 41737)
-- Name: ContactInformation usersUnique1; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactInformation"
    ADD CONSTRAINT "usersUnique1" UNIQUE (email);


--
-- TOC entry 2988 (class 2606 OID 41739)
-- Name: ContactInformation usersUnique2; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactInformation"
    ADD CONSTRAINT "usersUnique2" UNIQUE ("phoneNo");


--
-- TOC entry 3031 (class 2620 OID 50027)
-- Name: Driver addingControl; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "addingControl" BEFORE INSERT OR UPDATE ON public."Driver" FOR EACH ROW EXECUTE FUNCTION public."addDriverTR1"();


--
-- TOC entry 3029 (class 2620 OID 49964)
-- Name: ContactInformation createEmail; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "createEmail" BEFORE INSERT ON public."ContactInformation" FOR EACH ROW EXECUTE FUNCTION public."addContactInformation"();


--
-- TOC entry 3033 (class 2620 OID 42066)
-- Name: Trip driverTR3; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "driverTR3" AFTER INSERT ON public."Trip" FOR EACH ROW EXECUTE FUNCTION public."setStatus"();


--
-- TOC entry 3030 (class 2620 OID 42015)
-- Name: Driver onSalaryUpdate; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "onSalaryUpdate" BEFORE UPDATE ON public."Driver" FOR EACH ROW EXECUTE FUNCTION public."salaryChangesTR"();


--
-- TOC entry 3034 (class 2620 OID 50022)
-- Name: Reservation reservationTR; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "reservationTR" AFTER INSERT ON public."Reservation" FOR EACH ROW EXECUTE FUNCTION public."updateTrip"();


--
-- TOC entry 3032 (class 2620 OID 49980)
-- Name: Trip tripTR1; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "tripTR1" BEFORE DELETE ON public."Trip" FOR EACH ROW EXECUTE FUNCTION public."controlStatus"();


--
-- TOC entry 3010 (class 2606 OID 41590)
-- Name: Bus busFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Bus"
    ADD CONSTRAINT "busFK" FOREIGN KEY (company) REFERENCES public."Company"("companyID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3011 (class 2606 OID 41522)
-- Name: City cityFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."City"
    ADD CONSTRAINT "cityFK" FOREIGN KEY ("districtNo") REFERENCES public."District"("districtNo");


--
-- TOC entry 3009 (class 2606 OID 41585)
-- Name: Company companyFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Company"
    ADD CONSTRAINT "companyFK" FOREIGN KEY ("districtNo") REFERENCES public."District"("districtNo") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3012 (class 2606 OID 41548)
-- Name: ContactInformation contactInformationFK1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactInformation"
    ADD CONSTRAINT "contactInformationFK1" FOREIGN KEY ("districtNo") REFERENCES public."District"("districtNo");


--
-- TOC entry 3013 (class 2606 OID 41553)
-- Name: ContactInformation contactInformationFK2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ContactInformation"
    ADD CONSTRAINT "contactInformationFK2" FOREIGN KEY (company) REFERENCES public."Company"("companyID");


--
-- TOC entry 3014 (class 2606 OID 41570)
-- Name: Driver driverFK1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Driver"
    ADD CONSTRAINT "driverFK1" FOREIGN KEY ("plateNo") REFERENCES public."Bus"("plateNo") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3015 (class 2606 OID 41575)
-- Name: Driver driverFK2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Driver"
    ADD CONSTRAINT "driverFK2" FOREIGN KEY (contact) REFERENCES public."ContactInformation"("contactID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3016 (class 2606 OID 41580)
-- Name: Driver driverFK3; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Driver"
    ADD CONSTRAINT "driverFK3" FOREIGN KEY (company) REFERENCES public."Company"("companyID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3017 (class 2606 OID 41605)
-- Name: Passenger passengerFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Passenger"
    ADD CONSTRAINT "passengerFK" FOREIGN KEY (contact) REFERENCES public."ContactInformation"("contactID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3018 (class 2606 OID 41623)
-- Name: Payment paymentFK1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Payment"
    ADD CONSTRAINT "paymentFK1" FOREIGN KEY (passenger) REFERENCES public."Passenger"("passengerID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3019 (class 2606 OID 41700)
-- Name: Payment paymentFK2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Payment"
    ADD CONSTRAINT "paymentFK2" FOREIGN KEY (reservation) REFERENCES public."Reservation"("reservationID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3024 (class 2606 OID 41690)
-- Name: Reservation reservationFK1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reservation"
    ADD CONSTRAINT "reservationFK1" FOREIGN KEY ("passengerID") REFERENCES public."Passenger"("passengerID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3025 (class 2606 OID 41695)
-- Name: Reservation reservationFK2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reservation"
    ADD CONSTRAINT "reservationFK2" FOREIGN KEY ("tripID") REFERENCES public."Trip"("tripID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3026 (class 2606 OID 41713)
-- Name: Reservation reservationFK3; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reservation"
    ADD CONSTRAINT "reservationFK3" FOREIGN KEY ("ticketID") REFERENCES public."Ticket"("ticketID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3027 (class 2606 OID 49965)
-- Name: Reservation reservationFK4; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reservation"
    ADD CONSTRAINT "reservationFK4" FOREIGN KEY (discount) REFERENCES public."Discount"("discountID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3023 (class 2606 OID 41677)
-- Name: Route routeFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Route"
    ADD CONSTRAINT "routeFK" FOREIGN KEY (station) REFERENCES public."Station"("stationID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3028 (class 2606 OID 49981)
-- Name: Ticket ticketFK1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ticket"
    ADD CONSTRAINT "ticketFK1" FOREIGN KEY (trip) REFERENCES public."Trip"("tripID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3020 (class 2606 OID 41646)
-- Name: Trip tripFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Trip"
    ADD CONSTRAINT "tripFK" FOREIGN KEY (bus) REFERENCES public."Bus"("plateNo") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3021 (class 2606 OID 41651)
-- Name: Trip tripFK2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Trip"
    ADD CONSTRAINT "tripFK2" FOREIGN KEY (driver) REFERENCES public."Driver"("driverID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3022 (class 2606 OID 41664)
-- Name: Trip tripFK3; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Trip"
    ADD CONSTRAINT "tripFK3" FOREIGN KEY (route) REFERENCES public."Route"("routeID") ON UPDATE CASCADE ON DELETE CASCADE;


-- Completed on 2021-12-16 16:50:10

--
-- PostgreSQL database dump complete
--

