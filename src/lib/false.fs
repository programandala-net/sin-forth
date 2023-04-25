\ lib/false.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require push-hl.fs \ `push-hl`

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
