\ lib/false.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1823+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
