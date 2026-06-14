---
source_file: "docs/DATABASE.md"
type: "document"
community: "Community 0"
tags:
  - graphify/document
  - graphify/EXTRACTED
  - community/Community_0
---

# Database Data Model Overview (10 tables)

## Connections
- [[ASUGAK System (Academic Defense Management System)]] - `references` [EXTRACTED]
- [[Diplomnik DB Entity (FioImen, Tema, OrigVkr, Srball)]] - `references` [EXTRACTED]
- [[Docs DB Entity (Attached Documents)]] - `references` [EXTRACTED]
- [[Full Database Schema with Detailed Field Definitions]] - `semantically_similar_to` [INFERRED]
- [[Gak DB Entity (NomerPrikaza, KolvoBudget, KolvoPlatka)]] - `references` [EXTRACTED]
- [[Kafedra DB Entity (Id, Name, ShortName, Description)]] - `references` [EXTRACTED]
- [[NapravleniePodgotovki DB Entity (Nazvanie, ShifrNapr)]] - `references` [EXTRACTED]
- [[Oplata DB Entity (Payment to Commission Members)]] - `references` [EXTRACTED]
- [[PeriodZasedania DB Entity (DateStart, DateEnd, KafedraId)]] - `references` [EXTRACTED]
- [[Person DB Entity (Id, Name, Stepen, Zvanie, Role Flags)]] - `references` [EXTRACTED]
- [[ProfilPodgotovki DB Entity (Name, ShifrPodgot, NapravlenieID)]] - `references` [EXTRACTED]
- [[Zasedanie DB Entity (NapravleniePodgotovki, Kvalificacia, Date)]] - `references` [EXTRACTED]

#graphify/document #graphify/EXTRACTED #community/Community_0