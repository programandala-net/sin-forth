\ lib/true.fs

\ This file is part of Sin Forth.

\ This file adds `true` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012122003.
\ See change log at the end of the file.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

: true ( -- true )
  $FFFF h ldp#, \ ld hl,$FFFF
  push-hl ;

  \ doc{
  \
  \ true ( -- true )
  \
  \ Return a true flag, a single-cell value with all its bits
  \ set (equivalent to `-1`).
  \
  \ See also: `false`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-12: Start.
