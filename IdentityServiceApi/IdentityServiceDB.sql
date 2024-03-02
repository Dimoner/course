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
-- Name: FriendRequests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."FriendRequests" (
    "Id" uuid NOT NULL,
    "SenderUserId" uuid NOT NULL,
    "ReceiverUserId" uuid NOT NULL,
    "Status" integer NOT NULL
);


ALTER TABLE public."FriendRequests" OWNER TO postgres;

--
-- Name: Friendships; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Friendships" (
    "Id" uuid NOT NULL,
    "UserId1" uuid NOT NULL,
    "UserId2" uuid NOT NULL
);


ALTER TABLE public."Friendships" OWNER TO postgres;

--
-- Name: RefreshTokens; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RefreshTokens" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Token" text NOT NULL,
    "ExpiresAt" timestamp without time zone NOT NULL
);


ALTER TABLE public."RefreshTokens" OWNER TO postgres;

--
-- Name: Rights; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Rights" (
    "Id" uuid NOT NULL,
    "Name" character varying(50)
);


ALTER TABLE public."Rights" OWNER TO postgres;

--
-- Name: RoleRights; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RoleRights" (
    "RoleId" uuid NOT NULL,
    "RightId" uuid NOT NULL
);


ALTER TABLE public."RoleRights" OWNER TO postgres;

--
-- Name: Roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Roles" (
    "Id" uuid NOT NULL,
    "Name" character varying(50)
);


ALTER TABLE public."Roles" OWNER TO postgres;

--
-- Name: Sessions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sessions" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Token" text NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "ExpiresAt" timestamp without time zone NOT NULL
);


ALTER TABLE public."Sessions" OWNER TO postgres;

--
-- Name: UserProfiles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserProfiles" (
    "Id" uuid NOT NULL,
    "Status" character varying(50),
    "AvatarUrl" character varying(100) NOT NULL,
    "BirthDate" date,
    "UserId" uuid NOT NULL
);


ALTER TABLE public."UserProfiles" OWNER TO postgres;

--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "FirstName" character varying(50) NOT NULL,
    "LastName" character varying(50) NOT NULL,
    "Email" character varying(100) NOT NULL,
    "Age" integer,
    "RegistrationDate" date NOT NULL,
    "Password" character varying(100) NOT NULL,
    "RoleId" uuid
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- Data for Name: FriendRequests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."FriendRequests" ("Id", "SenderUserId", "ReceiverUserId", "Status") FROM stdin;
\.


--
-- Data for Name: Friendships; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Friendships" ("Id", "UserId1", "UserId2") FROM stdin;
\.


--
-- Data for Name: RefreshTokens; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RefreshTokens" ("Id", "UserId", "Token", "ExpiresAt") FROM stdin;
\.


--
-- Data for Name: Rights; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Rights" ("Id", "Name") FROM stdin;
\.


--
-- Data for Name: RoleRights; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RoleRights" ("RoleId", "RightId") FROM stdin;
\.


--
-- Data for Name: Roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Roles" ("Id", "Name") FROM stdin;
\.


--
-- Data for Name: Sessions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Sessions" ("Id", "UserId", "Token", "CreatedAt", "ExpiresAt") FROM stdin;
\.


--
-- Data for Name: UserProfiles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserProfiles" ("Id", "Status", "AvatarUrl", "BirthDate", "UserId") FROM stdin;
\.


--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("Id", "FirstName", "LastName", "Email", "Age", "RegistrationDate", "Password", "RoleId") FROM stdin;
\.


--
-- Name: Friendships Friendship_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Friendships"
    ADD CONSTRAINT "Friendship_pkey" PRIMARY KEY ("Id", "UserId1", "UserId2");


--
-- Name: RefreshTokens RefreshToken_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshTokens"
    ADD CONSTRAINT "RefreshToken_pkey" PRIMARY KEY ("Id");


--
-- Name: Rights Right_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Rights"
    ADD CONSTRAINT "Right_pkey" PRIMARY KEY ("Id");


--
-- Name: RoleRights RoleRights_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleRights"
    ADD CONSTRAINT "RoleRights_pkey" PRIMARY KEY ("RoleId", "RightId");


--
-- Name: Roles Role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Roles"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("Id");


--
-- Name: FriendRequests friendrequest_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FriendRequests"
    ADD CONSTRAINT friendrequest_pkey PRIMARY KEY ("Id");


--
-- Name: Sessions session_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sessions"
    ADD CONSTRAINT session_pkey PRIMARY KEY ("Id");


--
-- Name: UserProfiles userprofiles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserProfiles"
    ADD CONSTRAINT userprofiles_pkey PRIMARY KEY ("Id");


--
-- Name: UserProfiles userprofiles_user_id_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserProfiles"
    ADD CONSTRAINT userprofiles_user_id_key UNIQUE ("UserId");


--
-- Name: Users users_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT users_email_key UNIQUE ("Email");


--
-- Name: Users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT users_pkey PRIMARY KEY ("Id");


--
-- Name: Friendships Friendship_UserId1_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Friendships"
    ADD CONSTRAINT "Friendship_UserId1_fkey" FOREIGN KEY ("UserId1") REFERENCES public."Users"("Id");


--
-- Name: Friendships Friendship_UserId2_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Friendships"
    ADD CONSTRAINT "Friendship_UserId2_fkey" FOREIGN KEY ("UserId2") REFERENCES public."Users"("Id");


--
-- Name: RefreshTokens RefreshToken_UserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshTokens"
    ADD CONSTRAINT "RefreshToken_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- Name: RoleRights RoleRights_RightId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleRights"
    ADD CONSTRAINT "RoleRights_RightId_fkey" FOREIGN KEY ("RightId") REFERENCES public."Rights"("Id");


--
-- Name: RoleRights RoleRights_RoleId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleRights"
    ADD CONSTRAINT "RoleRights_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id");


--
-- Name: Users User_RoleId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "User_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id");


--
-- Name: FriendRequests friendrequest_ReceiverUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FriendRequests"
    ADD CONSTRAINT "friendrequest_ReceiverUserId_fkey" FOREIGN KEY ("ReceiverUserId") REFERENCES public."Users"("Id");


--
-- Name: FriendRequests friendrequest_SenderUserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FriendRequests"
    ADD CONSTRAINT "friendrequest_SenderUserId_fkey" FOREIGN KEY ("SenderUserId") REFERENCES public."Users"("Id");


--
-- Name: Sessions session_UserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sessions"
    ADD CONSTRAINT "session_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- Name: UserProfiles userprofiles_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserProfiles"
    ADD CONSTRAINT userprofiles_user_id_fkey FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- PostgreSQL database dump complete
--

