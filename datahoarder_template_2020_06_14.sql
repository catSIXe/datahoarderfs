--
-- PostgreSQL database dump
--

-- Dumped from database version 12.3 (Ubuntu 12.3-1.pgdg20.04+1)
-- Dumped by pg_dump version 12.3 (Ubuntu 12.3-1.pgdg20.04+1)

-- Started on 2020-06-14 03:23:03 UTC

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 203 (class 1259 OID 17452)
-- Name: containers; Type: TABLE; Schema: public; Owner: datahoarderfs
--

CREATE TABLE public.containers (
    id uuid NOT NULL,
    name text NOT NULL,
    creator text NOT NULL
);


ALTER TABLE public.containers OWNER TO datahoarderfs;

--
-- TOC entry 202 (class 1259 OID 17439)
-- Name: files; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.files (
    id uuid NOT NULL,
    filename text NOT NULL,
    owner text
);


ALTER TABLE public.files OWNER TO postgres;

--
-- TOC entry 2931 (class 0 OID 17452)
-- Dependencies: 203
-- Data for Name: containers; Type: TABLE DATA; Schema: public; Owner: datahoarderfs
--

COPY public.containers (id, name, creator) FROM stdin;
\.


--
-- TOC entry 2930 (class 0 OID 17439)
-- Dependencies: 202
-- Data for Name: files; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.files (id, filename, owner) FROM stdin;
\.


--
-- TOC entry 2803 (class 2606 OID 17459)
-- Name: containers containers_pkey; Type: CONSTRAINT; Schema: public; Owner: datahoarderfs
--

ALTER TABLE ONLY public.containers
    ADD CONSTRAINT containers_pkey PRIMARY KEY (id);


--
-- TOC entry 2799 (class 2606 OID 17448)
-- Name: files files_filename_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.files
    ADD CONSTRAINT files_filename_key UNIQUE (filename);


--
-- TOC entry 2801 (class 2606 OID 17446)
-- Name: files files_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.files
    ADD CONSTRAINT files_pkey PRIMARY KEY (id);


--
-- TOC entry 2937 (class 0 OID 0)
-- Dependencies: 202
-- Name: TABLE files; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.files TO datahoarderfs;


-- Completed on 2020-06-14 03:23:03 UTC

--
-- PostgreSQL database dump complete
--

