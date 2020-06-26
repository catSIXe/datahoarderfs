--
-- PostgreSQL database dump
--

-- Dumped from database version 12.3 (Ubuntu 12.3-1.pgdg20.04+1)
-- Dumped by pg_dump version 12.3 (Ubuntu 12.3-1.pgdg20.04+1)

-- Started on 2020-06-26 07:53:32 UTC

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
-- TOC entry 205 (class 1259 OID 17676)
-- Name: chunks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.chunks (
    id uuid NOT NULL,
    "order" bigint NOT NULL,
    size bigint NOT NULL,
    file_id uuid NOT NULL
);


ALTER TABLE public.chunks OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 17475)
-- Name: containers; Type: TABLE; Schema: public; Owner: datahoarderfs
--

CREATE TABLE public.containers (
    id uuid NOT NULL,
    name text NOT NULL,
    creator text NOT NULL
);


ALTER TABLE public.containers OWNER TO datahoarderfs;

--
-- TOC entry 206 (class 1259 OID 17702)
-- Name: file_versions_chunks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.file_versions_chunks (
    fileversion_id uuid NOT NULL,
    chunk_id uuid NOT NULL
);


ALTER TABLE public.file_versions_chunks OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 17512)
-- Name: files; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.files (
    id uuid NOT NULL,
    container_id uuid,
    filename text NOT NULL,
    owner text
);


ALTER TABLE public.files OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 17656)
-- Name: fileversions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.fileversions (
    id uuid NOT NULL,
    file_id uuid NOT NULL,
    date date NOT NULL,
    size bigint NOT NULL
);


ALTER TABLE public.fileversions OWNER TO postgres;

--
-- TOC entry 2958 (class 0 OID 17676)
-- Dependencies: 205
-- Data for Name: chunks; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.chunks (id, "order", size, file_id) FROM stdin;
\.


--
-- TOC entry 2955 (class 0 OID 17475)
-- Dependencies: 202
-- Data for Name: containers; Type: TABLE DATA; Schema: public; Owner: datahoarderfs
--

COPY public.containers (id, name, creator) FROM stdin;
\.


--
-- TOC entry 2959 (class 0 OID 17702)
-- Dependencies: 206
-- Data for Name: file_versions_chunks; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.file_versions_chunks (fileversion_id, chunk_id) FROM stdin;
\.


--
-- TOC entry 2956 (class 0 OID 17512)
-- Dependencies: 203
-- Data for Name: files; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.files (id, container_id, filename, owner) FROM stdin;
\.


--
-- TOC entry 2957 (class 0 OID 17656)
-- Dependencies: 204
-- Data for Name: fileversions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.fileversions (id, file_id, date, size) FROM stdin;
\.


--
-- TOC entry 2821 (class 2606 OID 17680)
-- Name: chunks chunks_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.chunks
    ADD CONSTRAINT chunks_pkey PRIMARY KEY (id);


--
-- TOC entry 2811 (class 2606 OID 17484)
-- Name: containers containers_name_key; Type: CONSTRAINT; Schema: public; Owner: datahoarderfs
--

ALTER TABLE ONLY public.containers
    ADD CONSTRAINT containers_name_key UNIQUE (name);


--
-- TOC entry 2813 (class 2606 OID 17482)
-- Name: containers containers_pkey; Type: CONSTRAINT; Schema: public; Owner: datahoarderfs
--

ALTER TABLE ONLY public.containers
    ADD CONSTRAINT containers_pkey PRIMARY KEY (id);


--
-- TOC entry 2823 (class 2606 OID 17706)
-- Name: file_versions_chunks file_versions_chunks_unique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.file_versions_chunks
    ADD CONSTRAINT file_versions_chunks_unique UNIQUE (fileversion_id, chunk_id);


--
-- TOC entry 2815 (class 2606 OID 17521)
-- Name: files files_filename_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.files
    ADD CONSTRAINT files_filename_key UNIQUE (filename, container_id);


--
-- TOC entry 2817 (class 2606 OID 17519)
-- Name: files files_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.files
    ADD CONSTRAINT files_pkey PRIMARY KEY (id);


--
-- TOC entry 2819 (class 2606 OID 17660)
-- Name: fileversions fileversions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fileversions
    ADD CONSTRAINT fileversions_pkey PRIMARY KEY (id);


--
-- TOC entry 2828 (class 2606 OID 17712)
-- Name: file_versions_chunks chunks_chunk_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.file_versions_chunks
    ADD CONSTRAINT chunks_chunk_id_fkey FOREIGN KEY (chunk_id) REFERENCES public.chunks(id);


--
-- TOC entry 2826 (class 2606 OID 17681)
-- Name: chunks chunks_file_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.chunks
    ADD CONSTRAINT chunks_file_id_fkey FOREIGN KEY (file_id) REFERENCES public.files(id);


--
-- TOC entry 2827 (class 2606 OID 17707)
-- Name: file_versions_chunks chunks_fileversion_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.file_versions_chunks
    ADD CONSTRAINT chunks_fileversion_id_fkey FOREIGN KEY (fileversion_id) REFERENCES public.fileversions(id);


--
-- TOC entry 2824 (class 2606 OID 17522)
-- Name: files files_container_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.files
    ADD CONSTRAINT files_container_id_fkey FOREIGN KEY (container_id) REFERENCES public.containers(id);


--
-- TOC entry 2825 (class 2606 OID 17661)
-- Name: fileversions fileversions_file_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fileversions
    ADD CONSTRAINT fileversions_file_id_fkey FOREIGN KEY (file_id) REFERENCES public.files(id);


--
-- TOC entry 2965 (class 0 OID 0)
-- Dependencies: 203
-- Name: TABLE files; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.files TO datahoarderfs;


-- Completed on 2020-06-26 07:53:32 UTC

--
-- PostgreSQL database dump complete
--

