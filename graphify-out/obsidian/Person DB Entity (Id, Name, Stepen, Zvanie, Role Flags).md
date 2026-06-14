---
source_file: "docs/DATABASE.md"
type: "concept"
community: "Community 0"
tags:
  - graphify/concept
  - graphify/EXTRACTED
  - community/Community_0
---

# Person DB Entity (Id, Name, Stepen, Zvanie, Role Flags)

## Connections
- [[Database Data Model Overview (10 tables)]] - `references` [EXTRACTED]
- [[Diplomnik DB Entity (FioImen, Tema, OrigVkr, Srball)]] - `shares_data_with` [EXTRACTED]
- [[Docs DB Entity (Attached Documents)]] - `shares_data_with` [EXTRACTED]
- [[Kafedra DB Entity (Id, Name, ShortName, Description)]] - `shares_data_with` [EXTRACTED]
- [[Oplata DB Entity (Payment to Commission Members)]] - `shares_data_with` [EXTRACTED]
- [[Person (StaffReviewer) Entity]] - `semantically_similar_to` [INFERRED]
- [[Person Extended Fields (PassportSeria, Snils, Inn, Phone, Email, Address)]] - `conceptually_related_to` [EXTRACTED]
- [[Person Test Data Seed (20+ sample commission members)]] - `shares_data_with` [EXTRACTED]
- [[PersonZasedanie (Many-to-Many Person - Zasedanie with RolVGek)]] - `shares_data_with` [EXTRACTED]

#graphify/concept #graphify/EXTRACTED #community/Community_0