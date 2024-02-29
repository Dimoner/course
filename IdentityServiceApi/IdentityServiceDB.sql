--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.2

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
-- Name: FriendRequest; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."FriendRequest" (
    "Id" uuid NOT NULL,
    "SenderUserId" uuid NOT NULL,
    "ReceiverUserId" uuid NOT NULL,
    "Status" integer NOT NULL
);


ALTER TABLE public."FriendRequest" OWNER TO postgres;

--
-- Name: Friendship; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Friendship" (
    "Id" uuid NOT NULL,
    "UserId1" uuid NOT NULL,
    "UserId2" uuid NOT NULL
);


ALTER TABLE public."Friendship" OWNER TO postgres;

--
-- Name: RefreshToken; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RefreshToken" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Token" text NOT NULL,
    "ExpiresAt" timestamp without time zone NOT NULL
);


ALTER TABLE public."RefreshToken" OWNER TO postgres;

--
-- Name: Right; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Right" (
    "Id" uuid NOT NULL,
    "Name" character varying(50)
);


ALTER TABLE public."Right" OWNER TO postgres;

--
-- Name: Role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Role" (
    "Id" uuid NOT NULL,
    "Name" character varying(50)
);


ALTER TABLE public."Role" OWNER TO postgres;

--
-- Name: RoleRights; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RoleRights" (
    "RoleId" uuid NOT NULL,
    "RightId" uuid NOT NULL
);


ALTER TABLE public."RoleRights" OWNER TO postgres;

--
-- Name: Session; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Session" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Token" text NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "ExpiresAt" timestamp without time zone NOT NULL
);


ALTER TABLE public."Session" OWNER TO postgres;

--
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."User" (
    "Id" uuid NOT NULL,
    "FirstName" character varying(50) NOT NULL,
    "LastName" character varying(50) NOT NULL,
    "Email" character varying(100) NOT NULL,
    "Age" integer,
    "RegistrationDate" date NOT NULL,
    "Password" character varying(100) NOT NULL,
    "RoleId" uuid
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- Name: UserProfile; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserProfile" (
    "Id" uuid NOT NULL,
    "Status" character varying(50),
    "AvatarUrl" character varying(100) NOT NULL,
    "RegistrationDate" date,
    "UserId" uuid NOT NULL
);


ALTER TABLE public."UserProfile" OWNER TO postgres;

--
-- Data for Name: FriendRequest; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."FriendRequest" ("Id", "SenderUserId", "ReceiverUserId", "Status") FROM stdin;
\.


--
-- Data for Name: Friendship; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Friendship" ("Id", "UserId1", "UserId2") FROM stdin;
\.


--
-- Data for Name: RefreshToken; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RefreshToken" ("Id", "UserId", "Token", "ExpiresAt") FROM stdin;
\.


--
-- Data for Name: Right; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Right" ("Id", "Name") FROM stdin;
\.


--
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Role" ("Id", "Name") FROM stdin;
\.


--
-- Data for Name: RoleRights; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RoleRights" ("RoleId", "RightId") FROM stdin;
\.


--
-- Data for Name: Session; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Session" ("Id", "UserId", "Token", "CreatedAt", "ExpiresAt") FROM stdin;
\.


--
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."User" ("Id", "FirstName", "LastName", "Email", "Age", "RegistrationDate", "Password", "RoleId") FROM stdin;
\.


--
-- Data for Name: UserProfile; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserProfile" ("Id", "Status", "AvatarUrl", "RegistrationDate", "UserId") FROM stdin;
\.


--
-- Name: Friendship Friendship_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Friendship"
    ADD CONSTRAINT "Friendship_pkey" PRIMARY KEY ("Id", "UserId1", "UserId2");


--
-- Name: RefreshToken RefreshToken_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshToken"
    ADD CONSTRAINT "RefreshToken_pkey" PRIMARY KEY ("Id");


--
-- Name: Right Right_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Right"
    ADD CONSTRAINT "Right_pkey" PRIMARY KEY ("Id");


--
-- Name: RoleRights RoleRights_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleRights"
    ADD CONSTRAINT "RoleRights_pkey" PRIMARY KEY ("RoleId", "RightId");


--
-- Name: Role Role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("Id");


--
-- Name: FriendRequest friendrequest_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FriendRequest"
    ADD CONSTRAINT friendrequest_pkey PRIMARY KEY ("Id");


--
-- Name: Session session_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Session"
    ADD CONSTRAINT session_pkey PRIMARY KEY ("Id");


--
-- Name: UserProfile userprofiles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserProfile"
    ADD CONSTRAINT userprofiles_pkey PRIMARY KEY ("Id");


--
-- Name: UserProfile userprofiles_user_id_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserProfile"
    ADD CONSTRAINT userprofiles_user_id_key UNIQUE ("UserId");


--
-- Name: User users_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT users_email_key UNIQUE ("Email");


--
-- Name: User users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT users_pkey PRIMARY KEY ("Id");


--
-- Name: Friendship Friendship_UserId1_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Friendship"
    ADD CONSTRAINT "Friendship_UserId1_fkey" FOREIGN KEY ("UserId1") REFERENCES public."User"("Id");


--
-- Name: Friendship Friendship_UserId2_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Friendship"
    ADD CONSTRAINT "Friendship_UserId2_fkey" FOREIGN KEY ("UserId2") REFERENCES public."User"("Id");


--
-- Name: RefreshToken RefreshToken_UserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshToken"
    ADD CONSTRAINT "RefreshToken_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."User"("Id");


--
-- Name: RoleRights RoleRights_RightId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleRights"
    ADD CONSTRAINT "RoleRights_RightId_fkey" FOREIGN KEY ("RightId") REFERENCES public."Right"("Id");


--
-- Name: RoleRights RoleRights_RoleId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleRights"
    ADD CONSTRAINT "RoleRights_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("Id");


--
-- Name: User User_RoleId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("Id");


--
-- Name: FriendRequest friendrequest_ReceiverUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FriendRequest"
    ADD CONSTRAINT "friendrequest_ReceiverUserId_fkey" FOREIGN KEY ("ReceiverUserId") REFERENCES public."User"("Id");


--
-- Name: FriendRequest friendrequest_SenderUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FriendRequest"
    ADD CONSTRAINT "friendrequest_SenderUserId_fkey" FOREIGN KEY ("SenderUserId") REFERENCES public."User"("Id");


--
-- Name: Session session_UserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Session"
    ADD CONSTRAINT "session_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."User"("Id");


--
-- Name: UserProfile userprofiles_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserProfile"
    ADD CONSTRAINT userprofiles_user_id_fkey FOREIGN KEY ("UserId") REFERENCES public."User"("Id");


--
-- PostgreSQL database dump complete
--

