\ lib/forward-mark-comma.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230426T1152+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

get-order get-current

compiler-definitions

: >mark, ( -- orig )
  t-here 0 t-, ;

  \ doc{
  \
  \ >mark, ( C: -- orig ) "forward-mark-comma"
  \
  \ Compile a fake destination address of a Z80 jump opcode just
  \ compiled, and return the address _orig_ of that destination
  \ address, which must be later resolved by `>resolve`.
  \
  \ This variant of `>mark` is used by the assembler control-flow
  \ instruction `aif`.
  \
  \ }doc

set-current set-order
