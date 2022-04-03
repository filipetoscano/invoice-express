API Coverage
===============================================================================

| Entity            | %PC  | Progress |
|-------------------|-----:|---------:|
| Invoices          |  18% | 2/11     |
| Estimates         |  28% | 2/7      |
| Guides            |   0% | 0/8      |
| Purchase orders   |   0% | 0/7      |
| Clients           |  71% | 5/7      |
| Items             | 100% | 5/5      |
| Sequences         | 100% | 4/4      |
| Taxes / VAT rates | 100% | 5/5      |
| Accounts          |   0% | 0/4      |
| SAF-T             |   0% | 0/1      |
| *Overall*         |  39% | 23/59    |


Legend:
* ❌, Not implemented
* ✔️, Implemented and tested
* ⚠️, Implemented but untested
* ❗, Implemented but not working


Invoices (2/11)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ❌ | `InvoiceSendByEmailAsync`      | [Send by Email](https://www.invoicexpress.com/api-v2/invoices/send-by-email) |
| ❌ | `InvoicePdfGenerateAsync`      | [Generate PDF](https://www.invoicexpress.com/api-v2/invoices/generate-pdf) |
| ✔️ | `InvoiceListAsync`             | [List all](https://www.invoicexpress.com/api-v2/invoices/list-all) |
| ✔️ | `InvoiceGetAsync`              | [Get](https://www.invoicexpress.com/api-v2/invoices/get) |
| ❌ | `InvoiceCreateAsync`           | [Create](https://www.invoicexpress.com/api-v2/invoices/create) |
| ❌ | `InvoiceUpdateAsync`           | [Update](https://www.invoicexpress.com/api-v2/invoices/update) |
| ❌ | `InvoiceStateChangeAsync`      | [Change state](https://www.invoicexpress.com/api-v2/invoices/change-state) |
| ⚠️ | `InvoiceRelatedDocumentsAsync` | [Related documents](https://www.invoicexpress.com/api-v2/invoices/related-documents) |
| ⚠️ | `InvoicePaymentAsync`          | [Generate payment](https://www.invoicexpress.com/api-v2/invoices/generate-payment) |
| ❌ | `InvoicePaymentCancelAsync`    | [Cancel payment](https://www.invoicexpress.com/api-v2/invoices/cancel-payment) |
| ❌ | `InvoiceQrCodeImageAsync`      | [Get QR code](https://www.invoicexpress.com/api-v2/invoices/get-qrcode) |


Estimates (2/7)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ✔️ | `EstimateSendByEmailAsync` | [Send by Email](https://www.invoicexpress.com/api-v2/estimates/send-by-email-1) |
| ✔️ | `EstimatePdfGenerateAsync` | [Generate PDF](https://www.invoicexpress.com/api-v2/estimates/generate-pdf-1) |
| ✔️ | `EstimateListAsync`        | [List all](https://www.invoicexpress.com/api-v2/estimates/list-all-1) |
| ✔️ | `EstimateGetAsync`         | [Get](https://www.invoicexpress.com/api-v2/estimates/get-1) |
| ✔️ | `EstimateCreateAsync`      | [Create](https://www.invoicexpress.com/api-v2/estimates/create-1) | Only with existing client and items
| ✔️ | `EstimateUpdateAsync`      | [Update](https://www.invoicexpress.com/api-v2/estimates/update-1) |
| ✔️ | `EstimateStateChangeAsync` | [Change state](https://www.invoicexpress.com/api-v2/estimates/change-state-1) |


Guides (0/8)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ❌ | | [Send by Email](https://www.invoicexpress.com/api-v2/guides/send-by-email-2) |
| ❌ | | [Generate PDF](https://www.invoicexpress.com/api-v2/guides/generate-pdf-2) |
| ❌ | | [List all](https://www.invoicexpress.com/api-v2/guides/list-all-2) |
| ❌ | | [Get](https://www.invoicexpress.com/api-v2/guides/get-2) |
| ❌ | | [Create](https://www.invoicexpress.com/api-v2/guides/create-2) |
| ❌ | | [Update](https://www.invoicexpress.com/api-v2/guides/update-2) |
| ❌ | | [Change state](https://www.invoicexpress.com/api-v2/guides/change-state-2) |
| ❌ | | [Get QR code](https://www.invoicexpress.com/api-v2/guides/get-qrcode-2) |


Purchase orders (0/7)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ❌ | | [Send by Email](https://www.invoicexpress.com/api-v2/purchase-orders/send-by-email-3) |
| ❌ | | [Generate PDF](https://www.invoicexpress.com/api-v2/purchase-orders/generate-pdf-3) |
| ❌ | | [List all](https://www.invoicexpress.com/api-v2/purchase-orders/list-all-3) |
| ❌ | | [Get](https://www.invoicexpress.com/api-v2/purchase-orders/get-3) |
| ❌ | | [Create](https://www.invoicexpress.com/api-v2/purchase-orders/create-3) |
| ❌ | | [Update](https://www.invoicexpress.com/api-v2/purchase-orders/update-3) |
| ❌ | | [Change state](https://www.invoicexpress.com/api-v2/purchase-orders/change-state-3) |


Clients (5/7)
-------------------------------------------------------------------------------

| I? | Method                | Method                                  | Notes |
|----|-----------------------|-----------------------------------------|-------|
| ✔️ | `ClientListAsync`      | [List all](https://www.invoicexpress.com/api-v2/clients/list-all-4) |
| ✔️ | `ClientGetAsync`       | [Get](https://www.invoicexpress.com/api-v2/clients/get-4) |
| ✔️ | `ClientCreateAsync`    | [Create](https://www.invoicexpress.com/api-v2/clients/create-4) |
| ✔️ | `ClientUpdateAsync`    | [Update](https://www.invoicexpress.com/api-v2/clients/update-4) |
| ❌ |                       | [Find by name](https://www.invoicexpress.com/api-v2/clients/find-by-name) |
| ✔️ | `ClientGetByCodeAsync` | [Find by code](https://www.invoicexpress.com/api-v2/clients/find-by-code) |
| ❌ |                       | [List invoices](https://www.invoicexpress.com/api-v2/clients/list-invoices) |


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

| I? | Method                    | Method                              | Notes |
|----|---------------------------|-------------------------------------|-------|
| ✔️ | `SequenceListAsync`       | [List all](https://www.invoicexpress.com/api-v2/sequences/list-all-6) |
| ✔️ | `SequenceGetAsync`        | [Get](https://www.invoicexpress.com/api-v2/sequences/get-6) | Not all response fields are being mapped (the sequence Id)
| ✔️ | `SequenceCreateAsync`     | [Create](https://www.invoicexpress.com/api-v2/sequences/create-6) |
| ✔️ | `SequenceSetDefaultAsync` | [Update](https://www.invoicexpress.com/api-v2/sequences/update-6) |


VAT rates (5/5)
-------------------------------------------------------------------------------

| I? | Method               | Method                                   | Notes |
|----|----------------------|------------------------------------------|-------|
| ✔️ | `VatRateListAsync`   | [List all](https://www.invoicexpress.com/api-v2/taxes/list-all-7) |
| ✔️ | `VatRateGetAsync`    | [Get](https://www.invoicexpress.com/api-v2/taxes/get-7) |
| ✔️ | `VatRateCreateAsync` | [Create](https://www.invoicexpress.com/api-v2/taxes/create-7) | See issue #3
| ✔️ | `VatRateUpdateAsync` | [Update](https://www.invoicexpress.com/api-v2/taxes/update-7) |
| ✔️ | `VatRateDeleteAsync` | [Delete](https://www.invoicexpress.com/api-v2/taxes/delete-7) |


Accounts (0/4)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ❌ | | [Get](https://www.invoicexpress.com/api-v2/accounts/get-8) |
| ❌ | | [Create](https://www.invoicexpress.com/api-v2/accounts/create-8) |
| ❌ | | [Update](https://www.invoicexpress.com/api-v2/accounts/update-8) |
| ❌ | | [Create for existing user](https://www.invoicexpress.com/api-v2/accounts/create-for-existing-user) |


SAF-T (1/1)
-------------------------------------------------------------------------------

| I? | Method            | Method                                      | Notes |
|----|-------------------|---------------------------------------------|-------|
| ⚠️ | `SaftExportAsync` | [Export](https://www.invoicexpress.com/api-v2/saf-t/export-saft) | Cannot test with trial account |

