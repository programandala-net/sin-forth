\ lib/to-digit.fs

\ This file is part of Sin Forth.

\ This file adds `>digit` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261918.
\ See change log at the end of the file.

\ ==============================================================

require pop-hl.fs  \ `pop-hl`
require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

: >digit ( n -- c )
  pop-hl       \ call pop_hl
  l a ld,      \ ld a,l
  #10 cp#,     \ cp #10
  nc? rif      \ jr c,end
    7 add#,    \ add a,7
  rthen        \ end:
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

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
