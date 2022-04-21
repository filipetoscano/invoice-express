API Coverage
===============================================================================

| Entity            | %PC  | Progress | Notes |
|-------------------|-----:|---------:|-------|
| Invoices          | 100% | 11/11    |
| Estimates         | 100% | 7/7      |
| Guides            | 100% | 8/8      |
| Clients           |  85% | 6/7      |
| Items             | 100% | 5/5      |
| Sequences         | 100% | 4/4      |
| Taxes / VAT rates | 100% | 5/5      |
| Accounts          |  50% | 2/4      |
| SAF-T             | 100% | 1/1      | ⚠️ Can't test on trial account
| *Overall*         |  94% | 49/52    |


Legend:
* ❌, Not implemented
* ✔️, Implemented and tested
* 🔸, Partially implemented
* ⚠️, Implemented but untested
* ❗, Implemented but not working


Invoices (11/11)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ✔️ | `InvoiceSendByEmailAsync`      | [Send by Email](https://www.invoicexpress.com/api-v2/invoices/send-by-email) |
| ✔️ | `InvoicePdfGenerateAsync`      | [Generate PDF](https://www.invoicexpress.com/api-v2/invoices/generate-pdf) |
| ✔️ | `InvoiceListAsync`             | [List all](https://www.invoicexpress.com/api-v2/invoices/list-all) |
| ✔️ | `InvoiceGetAsync`              | [Get](https://www.invoicexpress.com/api-v2/invoices/get) |
| ✔️ | `InvoiceCreateAsync`           | [Create](https://www.invoicexpress.com/api-v2/invoices/create) | Only with existing client and items
| ✔️ | `InvoiceUpdateAsync`           | [Update](https://www.invoicexpress.com/api-v2/invoices/update) | (Same as above)
| ✔️ | `InvoiceStateChangeAsync`      | [Change state](https://www.invoicexpress.com/api-v2/invoices/change-state) |
| ✔️ | `InvoiceRelatedDocumentsAsync` | [Related documents](https://www.invoicexpress.com/api-v2/invoices/related-documents) |
| ✔️ | `InvoicePaymentAsync`          | [Generate payment](https://www.invoicexpress.com/api-v2/invoices/generate-payment) |
| ✔️ | `InvoicePaymentCancelAsync`    | [Cancel payment](https://www.invoicexpress.com/api-v2/invoices/cancel-payment) |
| ✔️ | `InvoiceQrCodeImageAsync`      | [Get QR code](https://www.invoicexpress.com/api-v2/invoices/get-qrcode) |


Estimates (7/7)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ✔️ | `EstimateSendByEmailAsync` | [Send by Email](https://www.invoicexpress.com/api-v2/estimates/send-by-email-1) |
| ✔️ | `EstimatePdfGenerateAsync` | [Generate PDF](https://www.invoicexpress.com/api-v2/estimates/generate-pdf-1) |
| ✔️ | `EstimateListAsync`        | [List all](https://www.invoicexpress.com/api-v2/estimates/list-all-1) |
| ✔️ | `EstimateGetAsync`         | [Get](https://www.invoicexpress.com/api-v2/estimates/get-1) |
| ✔️ | `EstimateCreateAsync`      | [Create](https://www.invoicexpress.com/api-v2/estimates/create-1) | Only with existing client and items
| ✔️ | `EstimateUpdateAsync`      | [Update](https://www.invoicexpress.com/api-v2/estimates/update-1) | (Same as above)
| ✔️ | `EstimateStateChangeAsync` | [Change state](https://www.invoicexpress.com/api-v2/estimates/change-state-1) |


Guides (8/8)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ✔️ | `GuideSendByEmailAsync` | [Send by Email](https://www.invoicexpress.com/api-v2/guides/send-by-email-2) |
| ✔️ | `GuidePdfGenerateAsync` | [Generate PDF](https://www.invoicexpress.com/api-v2/guides/generate-pdf-2) |
| ✔️ | `GuideListAsync`        | [List all](https://www.invoicexpress.com/api-v2/guides/list-all-2) |
| ✔️ | `GuideGetAsync`         | [Get](https://www.invoicexpress.com/api-v2/guides/get-2) |
| ✔️ | `GuideCreateAsync`      | [Create](https://www.invoicexpress.com/api-v2/guides/create-2) | Only with existing client and items
| ✔️ | `GuideUpdateAsync`      | [Update](https://www.invoicexpress.com/api-v2/guides/update-2) | (Same as above)
| ✔️ | `GuideStateChangeAsync` | [Change state](https://www.invoicexpress.com/api-v2/guides/change-state-2) |
| ✔️ | `GuideQrCodeImageAsync` | [Get QR code](https://www.invoicexpress.com/api-v2/guides/get-qrcode-2) |


Clients (6/7)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ✔️ | `ClientListAsync`      | [List all](https://www.invoicexpress.com/api-v2/clients/list-all-4) |
| ✔️ | `ClientGetAsync`       | [Get](https://www.invoicexpress.com/api-v2/clients/get-4) |
| ✔️ | `ClientCreateAsync`    | [Create](https://www.invoicexpress.com/api-v2/clients/create-4) |
| ✔️ | `ClientUpdateAsync`    | [Update](https://www.invoicexpress.com/api-v2/clients/update-4) |
| ❌ |                       | [Find by name](https://www.invoicexpress.com/api-v2/clients/find-by-name) |
| ✔️ | `ClientGetByCodeAsync` | [Find by code](https://www.invoicexpress.com/api-v2/clients/find-by-code) |
| ✔️ | `ClientInvoiceListAsync` | [List invoices](https://www.invoicexpress.com/api-v2/clients/list-invoices) |


Items (5/5)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ✔️ | `ItemListAsync`   | [List all](https://www.invoicexpress.com/api-v2/items/list-all-5) |
| ✔️ | `ItemGetAsync`    | [Get](https://www.invoicexpress.com/api-v2/items/get-5) |
| ✔️ | `ItemCreateAsync` | [Create](https://www.invoicexpress.com/api-v2/items/create-5) |
| ✔️ | `ItemUpdateAsync` | [Update](https://www.invoicexpress.com/api-v2/items/update-5) |
| ✔️ | `ItemDeleteAsync` | [Delete](https://www.invoicexpress.com/api-v2/items/delete) |


Sequences (4/4)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ✔️ | `SequenceListAsync`       | [List all](https://www.invoicexpress.com/api-v2/sequences/list-all-6) |
| ✔️ | `SequenceGetAsync`        | [Get](https://www.invoicexpress.com/api-v2/sequences/get-6) | Not all response fields are being mapped (the sequence Id)
| ✔️ | `SequenceCreateAsync`     | [Create](https://www.invoicexpress.com/api-v2/sequences/create-6) |
| ✔️ | `SequenceSetDefaultAsync` | [Update](https://www.invoicexpress.com/api-v2/sequences/update-6) |


VAT rates (5/5)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ✔️ | `VatRateListAsync`   | [List all](https://www.invoicexpress.com/api-v2/taxes/list-all-7) |
| ✔️ | `VatRateGetAsync`    | [Get](https://www.invoicexpress.com/api-v2/taxes/get-7) |
| ✔️ | `VatRateCreateAsync` | [Create](https://www.invoicexpress.com/api-v2/taxes/create-7) | See issue #3
| ✔️ | `VatRateUpdateAsync` | [Update](https://www.invoicexpress.com/api-v2/taxes/update-7) |
| ✔️ | `VatRateDeleteAsync` | [Delete](https://www.invoicexpress.com/api-v2/taxes/delete-7) |


Accounts (2/4)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ✔️ | | [Get](https://www.invoicexpress.com/api-v2/accounts/get-8) |
| ❌ | | [Create](https://www.invoicexpress.com/api-v2/accounts/create-8) |
| ✔️ | | [Update](https://www.invoicexpress.com/api-v2/accounts/update-8) |
| ❌ | | [Create for existing user](https://www.invoicexpress.com/api-v2/accounts/create-for-existing-user) |


SAF-T (1/1)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ⚠️ | `SaftExportAsync` | [Export](https://www.invoicexpress.com/api-v2/saf-t/export-saft) | Cannot test with trial account |

