\ lib/if.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require zero-branch.fs  \ `0branch`
require forward-mark.fs \ `>mark`

get-order get-current

compiler-definitions

: if \ Compilation: ( -- orig )
     \ Run-time:    ( f -- )
  compiler{ 0branch >mark } ;

  \ doc{
  \
  \ if
  \   Compilation: ( C: -- orig )
  \   Run-time:    ( f -- )

  \
  \ Compilation: Compile a conditional `0branch` and put the
  \ location _orig_ of its unresolved destination on the
  \ control-flow stack, to be resolved by `else` or `then`.
  \
  \ Run-time: If _f_ is zero, continue execution at the location
  \ specified by the resolution of _orig_.
  \
  \ // XXX TODO
  \ // See also: `again`, `until`, `ahead`, `0if`, `-if`, `+if`, `andif`, `orif`.
  \
  \ }doc

set-current set-order
