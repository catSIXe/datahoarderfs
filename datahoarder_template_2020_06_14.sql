PGDMP     ,                    x            datahoarder_template     12.3 (Ubuntu 12.3-1.pgdg20.04+1)     12.3 (Ubuntu 12.3-1.pgdg20.04+1)     v           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            w           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            x           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            y           1262    17438    datahoarder_template    DATABASE     r   CREATE DATABASE datahoarder_template WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'C' LC_CTYPE = 'C';
 $   DROP DATABASE datahoarder_template;
                datahoarderfs    false            �            1259    17452 
   containers    TABLE     l   CREATE TABLE public.containers (
    id uuid NOT NULL,
    name text NOT NULL,
    creator text NOT NULL
);
    DROP TABLE public.containers;
       public         heap    datahoarderfs    false            �            1259    17439    files    TABLE     `   CREATE TABLE public.files (
    id uuid NOT NULL,
    filename text NOT NULL,
    owner text
);
    DROP TABLE public.files;
       public         heap    postgres    false            z           0    0    TABLE files    ACL     2   GRANT ALL ON TABLE public.files TO datahoarderfs;
          public          postgres    false    202            s          0    17452 
   containers 
   TABLE DATA           7   COPY public.containers (id, name, creator) FROM stdin;
    public          datahoarderfs    false    203   �       r          0    17439    files 
   TABLE DATA           4   COPY public.files (id, filename, owner) FROM stdin;
    public          postgres    false    202   �       �
           2606    17459    containers containers_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.containers
    ADD CONSTRAINT containers_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.containers DROP CONSTRAINT containers_pkey;
       public            datahoarderfs    false    203            �
           2606    17448    files files_filename_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.files
    ADD CONSTRAINT files_filename_key UNIQUE (filename);
 B   ALTER TABLE ONLY public.files DROP CONSTRAINT files_filename_key;
       public            postgres    false    202            �
           2606    17446    files files_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.files
    ADD CONSTRAINT files_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.files DROP CONSTRAINT files_pkey;
       public            postgres    false    202            s      x������ � �      r      x������ � �     