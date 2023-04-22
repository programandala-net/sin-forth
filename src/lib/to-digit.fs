\ lib/to-digit.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require pop-hl.fs  \ `pop-hl`
require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

: >digit ( n -- c )
  pop-hl       \ call pop_hl
  l a ld,      \ ld a,l
  #10 cp#,     \ cp #10
  host{ cr .( before rif ) .s }
  nc? rif      \ jr c,end
  host{ cr .( after rif ) .s }
    7 add#,    \ add a,7
  host{ cr .( before rthen ) .s }
  rthen        \ end:
  host{ cr .( after rthen ) .s }
  $30 add#,    \ add a,$30
  a l ld,      \ ld l,a
  push-hl ;    \ jp push_hl

  \ Credit: Code adapted from Solo Forth, previously adapted from Z88
  \ CamelForth (Garry Lancaster, 2001).

  \ doc{
  \
  \ >digit ( n -- c ) "to-digit"
  \
  \ Convert a number to its character digit: 0 .. 9A .. Z.
  \
  \ See also: `<#`, `#`, `#s`, `#>`.
  \
  \ }doc

set-current set-order
