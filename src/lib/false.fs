\ lib/false.fs

\ This file is part of Sin Forth.

\ This file adds `false` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
