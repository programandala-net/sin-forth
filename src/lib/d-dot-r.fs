\ lib/d-dot-r.fs

\ This file is part of Sin Forth.

\ This file adds `d.r` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260413.
\ See change log at the end of the file.

\ ==============================================================

require d-to-s-t-r.fs \ `d>str`
require from-r.fs     \ `>r`
require minus.fs      \ `-`
require over.fs       \ `over`
require r-to.fs       \ `r>`
require spaces.fs     \ `spaces`
require type.fs       \ `type`

get-order get-current

target-definitions

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

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.