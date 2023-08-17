# August 17 Teknologi
## Intro / Review 
20 minutter
Der er ikke noget review denne gang
Kort intro til faget og skabelon for undervisning *(Intro / Review -> Opgaver -> Vidensdeling / Opsamling -> Outro)* og ikke mindst mine forventninger ift. forberedelse, deltagelse, time-framing og opgaveløsning.
Errata: Beskrivelsen af mesh-topologien i videoen er en smule upræcis og dermed forvirrende.
### Opgave 1a
5 minutter

Brug ”Ordet rundt” til at lokalisere emner fra forberedelsen som mindst en i gruppen fandt svært eller måske endda uforståeligt. 
### Opgave 1b
10 minutter

Hver gruppe fremlægger i plenum de emner de fandt svære 
### Opgave 2
10 minutter

1.	Nedskriv, i stikordsform, hvad du tror / ønsker, at hver af de 8 læringsmål til faget **Teknologi II** dækker over.

**Viden'**

Den studerende har:
* udviklingsbaseret viden om praksis og centralt anvendt teori inden for design og realisering
	- Selv finde information
af distribuerede systemer
* forståelse for fundamentale netværksbegreber
	- forståelse af fagbegreber og netværk

**Færdigheder**

Den studerende kan:
* anvende centrale redskaber til virtualisering
	- Visualisere sin viden
* anvende centrale og i praksis udbredte applikationsprotokoller
	- Praksisknær applikationsprotokoler
* vurdere praksisnære problemstillinger vedrørende centrale sikkerhedsmæssige begreber og trusler
	- Kenskab til sikkerhedbegreber og trusler
* vurdere relevante teknologiske aspekter i udviklingen af distribuerede systemer

**Kompetencer**

Den studerende kan:
* Varetage valg af infrastruktur i forbindelse med udvikling af distribuerede systemer
* I en struktureret sammenhæng tilegne sig ny viden, færdigheder indenfor distribuerede
systemer

Pause
15 minutter
### Opgave 3 
30 minutter (12 + 10 + 8)

Brug ”Tænk-Par-Del” til følgende opgaver (først tænkes over alle opgaver en for en, så parres opgaverne med sidekammeraten en for en og endelig deles opgaverne en for en (brug ”Ordet rundt”, hvor hvert par beskriver deres løsning for den aktuelle opgave).
1.	Beskriv kort forskellene på *LAN, WLAN, MAN og WAN*
Forklar hvilket netværk internettet er.
	- LAN
		+ Local Area Network
		+ Limited area, imagine a house, office, or smaller building
		+ It is very effective at transfering high rate of data at a low cost. But is highly limited by distance. 
	- WLAN
		+ Wireless local area network
		+ Bruger radio bøljer til at sender information rundt. Tænkt wifi eller mobildata
	- MAN
		+ metropolitan area network
		+ Et større område så som en by. Eksempel er glenten der levere på på tværs af en by
	- WAN
		+ Wide area Network
		+ på tværs af landegrænser
2.	Beskriv forskellen på et fysisk og et logisk netværk.
	-	Logisk
		+	www
		+	ports
		+	cloud
	-	Fysisk
		+	rutere og switches
		+	hardware
		+	kabler
3.	Fysisk netværk kan inddeles i to grupper: point-to-point connections og multipoint connections.
Forklar forskellen.
	- Point to point connections
		+ Kun 2 enheder der snakker sammen
	- multipoint connections
		+ mange enheder der snakker sammen
### Opgave 4 
25 minutter (12 – 7 – 6)

Brug ”Tænk-Par-Del” til følgende opgaver (først ”tænk” over alle 3 spørgsmål, så ”par” over alle 3 spørgsmål og endelig ”del” alle 3 spørgsmål):
![Image](./BillederTekno/Pic1Aug17.PNG "ArbejdsBillede")

1.	Beskriv kort de første 4 topologier fra ovenstående figuren
	1.	
2.	Hvilke af topologierne er point-to-point og hvilke er multipoint?
	1.	point to point
		1.	point to point
		2.	ring
	3.	multiconnection
		1.	Bus
		2.	star
		3.	mesh
		4.	tree (halvt)
3.	I hvilke situationer (opgavetyper) tror du de enkelte topologier vil blive valgt?
	1.	Bus
		1.	fiber forbindelse (f.eks MAN)
	2.	star
		1.	kontor, lager deling (f.eks LAN, WLAN)
	2.	ring
	3.	mesh
		1.	WLAN, WWW, TLF
	1.	tree
		1.	Stor virksomhed, med rigtig mange afdelinger f.eks microsoft
		2.	WLAN, LAN, WAN
	2.	point to point
		1.	kabel

### Opgave 5 
35 minutter

Arbejd sammen i par.
Beskriv, for hver af de første 4 topologier fra figuren i sidste opgave (bus, star, ring og mesh), hvordan følgende opgaver kan løses og om der er problemstillinger ifm. løsningen:
1. En besked skal sendes fra en PC til alle andre PC’ere på nettet
	1. Bus
		1. forbindelse i jorden blandt enheder, som sikre hurtig forbindelse. 
	2. star
		1. Sender en besked til hubben, som sender den videre til alle andre
		2. Der kommer en central enhed, som hvis går ned lukker for alt kommunikation mellem alle enheder. Så der er en stor usikkerhed ved denne løsning
	3. ring
		1. Alle siger tingen videre til den næste
	4. mesh
		1. Alle kan sende til alle
2.	En besked skal sendes fra en PC til en (og kun en) anden specifik PC på nettet
	1.	bus
		1.	??
	2.	star
		1.	Du sender en besked til en hub somm sender det videre til modtageren
		2.	hubben kan læse alt
	3.	ring
		1.	Efterspørger request, som bliver sendt rundt fra enhed til enhed. Indtil der er en der kan svare på den. 
		2.	Dette tager langt tid da alle, skal blive spurgt og det tager lang tid.
		3.	næsten ingen sikkerhed, da alle kan se beskeden
	4.	mesh
		1.	Alle kan sende til en specifik modtager
3.	En besked skal sendes fra en PC til en (og kun en) anden specifik PC på nettet som sender et svar tilbage.
	1.	bus
		1.	?
	2.	star
		1.	Sender en besked til en hubben med et adresse, som hubben sender videre. Modtager giver svar tilbage til hubben med besked om at sende til originale 
	3.	ring
		1.	sender besked med adresse, som bliver sendt fra person til person. Til den ender hos den rette. Som svare og sender videre rundt i cirklen til at den kommer fram til den originale pc. 
	4.	mesh
		1.	sender og svar
4.	Alle PC’er ønsker at sende en besked ud på nettet på præcis samme tidspunkt
	1.	bus
		1.	
	2.	star
	3.	ring
	4.	mesh
5.	Der sker et brud på et af kablerne (de sorte streger der forbinder PC’erne i figuren). Herefter ska en besked sendes fra en PC til en (og kun en) specifik PC på nettet.
	1.	bus
	2.	star
	3.	ring
	4.	mesh

Beskriv desuden forskellen på den første topologi (Bus) og den sjette topologi (Point-to-Point)


Ekstraopgave 
KUN hvis I er færdige med opgave 5 inden kl. 11:30!!
Giv et forslag til hvordan UCL skal designe sit netværk. Husk at UCL har uddannelser på flere lokationer (fx Seebladsgade, Noels Bohr Alle, Vejle, Jelling, Svendborg osv.)
Pause
45 minutter
### Opgave 6 
25 minutter (10 + 9 + 6)

Brug ”Tænk-Par-Del” til følgende opgaver:
1.	Beskriv formål med hvert enkelt lag i OSI-modellen
2.	    Fysisk lag (Physical Layer):
    Dette laget håndterer fysiske forbindelser og overføring av rå biter over medier som kabler og trådløse signaler.

    Datalink lag (Data Link Layer):
    Dette laget sikrer pålitelig overføring av data mellom naboer på samme nettverk og administrerer tilgangen til delte medier.

    Nettverkslag (Network Layer):
    Dette laget fokuserer på ruting av data mellom forskjellige nettverk og subnett, og tar beslutninger om den beste ruten for datapakker.

    Transportlag (Transport Layer):
    Dette laget tilbyr pålitelig dataoverføring mellom endepunkter, administrerer flytkontroll og kan implementere feilhåndtering.

    Sesjonslag (Session Layer):
    Dette laget oppretter, administrerer og avslutter sesjoner mellom applikasjoner, og inkluderer ofte sikkerhetsfunksjoner.

    Presentasjonslag (Presentation Layer):
    Dette laget håndterer datarepresentasjon, kryptering og komprimering, slik at data blir korrekt formatert for overføring.

    Applikasjonslag (Application Layer):
    Dette laget inneholder selve applikasjonene og brukergrensesnittene, og håndterer applikasjonsspesifikke protokoller og tjenester.
2.	Beskriv formål med hvert enkelt lag i TCP/IP-modellen
- TCP/IP-modellen:
	- Nettverkslag (Network Layer): Dette laget håndterer ruting av datapakker mellom forskjellige nettverk ved hjelp av IP-protokollen.
- Internettlag (Internet Layer):
	- Dette laget tar seg av adressering og fragmentering av datapakker, slik at de kan passere gjennom ulike nettverk. IP-protokollen opererer her.

- Transportlag (Transport Layer):
	- Dette laget tilbyr pålitelig dataoverføring mellom endepunkter ved hjelp av TCP og UDP-protokollene.

- Applikasjonslag (Application Layer):
	- Dette laget inneholder applikasjoner og tjenester som kommuniserer over nettverket, som HTTP, SMTP og FTP.


Opsamling / Outro 
20 minutter
*	Var der noget vi ikke nåede eller ikke fik behandlet tilstrækkeligt?
*	Hurtig gennemgang af nogle af opgaverne
*	Var det svært / nemt?
*	Lærte du tilstrækkeligt i dag?
Hvis nej: Hvad var årsagen?
