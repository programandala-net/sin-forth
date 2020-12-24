\ lib/false.fs

\ This file is part of Sin Forth.

\ This file adds `false` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012122003.
\ See change log at the end of the file.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

: false ( -- false )
  $0000 h ldp#, \ ld hl,$0000
  push-hl ;

  \ doc{
  \
  \ false ( -- false )
  \
  \ Return a false flag, a single-cell value with all its bits clear
  \ (equivalent to zero).
  \
  \ See also: `false`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-12: Start.

