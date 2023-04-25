\ lib/d-dot-r.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T1535+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require d-to-s-t-r.fs \ `d>str`
require minus.fs      \ `-`
require over.fs       \ `over`
require r-from.fs     \ `r>`
require spaces.fs     \ `spaces`
require to-r.fs       \ `>r`
require type.fs       \ `type`

: d.r ( d n -- )
  >r d>str r> over - spaces type ;

  \ doc{
  \
  \ d.r ( d n -- ) "d-dot-r"
  \
  \ Display _d_ right aligned in a field _n_ characters wide. If
  \ the number of characters required to display _d_ is greater
  \ than _n_, all digits are displayed with no leading spaces in a
  \ field as wide as necessary.
  \
  \ See also: `d>str`, `ud.r`, `.r`, `0d.r`, `<#`.
  \
  \ }doc
